﻿/***************************************************
* Copyright(C) 2021 by DefaultCompany              *
* All Rights Reserved By Author lihongliu.         *
* Author:            XiNan                         *
* Email:             1398581458@qq.com             *
* Version:           0.1                           *
* UnityVersion:      2018.4.36f1                   *
* Date:              2021-11-04                    *
* Nowtime:           18:17:31                      *
* Description:                                     *
* History:                                         *
***************************************************/

namespace Framework
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// 身份证判断方法
    /// </summary>
    public class IDNo
    {
        /// <summary>
        /// 18位二代身份证号码的正则表达式
        /// </summary>
        private const string REGEX_ID_NO_18 = "^"
            + "\\d{6}" // 6位地区码
            + "(18|19|([23]\\d))\\d{2}" // 年YYYY
            + "((0[1-9])|(10|11|12))" // 月MM
            + "(([0-2][1-9])|10|20|30|31)" // 日DD
            + "\\d{3}" // 3位顺序码
            + "[0-9Xx]" // 校验码
            + "$";

        /// <summary>
        /// 15位一代身份证号码的正则表达式
        /// </summary>
        private const string REGEX_ID_NO_15 = "^"
            + "\\d{6}" // 6位地区码
            + "\\d{2}" // 年YYYY
            + "((0[1-9])|(10|11|12))" // 月MM
            + "(([0-2][1-9])|10|20|30|31)" // 日DD
            + "\\d{3}"// 3位顺序码
            + "$";

        private static readonly string[] City = new string[]
        {
            null, null, null, null, null, null, null, null, null, null, null,
            "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁",
            "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏",
            "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南",
            "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏",
            null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "新疆",
            null, null, null, null, null, "台湾", null, null, null, null, null,
            null, null, null, null, "香港", "澳门", null, null, null, null, null,
            null, null, null, "国外"
        };

        /// <summary>
        /// 加权因子
        /// </summary>
        private static readonly int[] W = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };

        /// <summary>
        /// 判断当前字符是否符合中国身份证
        /// </summary>
        public static bool CheckIDNo(string IDNo)
        {
            if (string.IsNullOrEmpty(IDNo))
                return false;
            if (IDNo.Length == 18)
                return CheckIDNo18(IDNo);
            if (IDNo.Length == 15)
                return CheckIDNo18(UpdateIDNo15to18(IDNo));
            return false;
        }

        /// <summary>
        /// 判断当前字符是否符合中国18位身份证
        /// </summary>
        private static bool CheckIDNo18(string IDNo)
        {
            // 匹配身份证号码的正则表达式
            if (!Regex.IsMatch(IDNo, REGEX_ID_NO_18))
            {
                return false;
            }
            // 校验身份证号码的验证码
            return ValidateCheckNumber(IDNo);
        }

        public static string UpdateIDNo15to18(string IDNo)
        {
            // 匹配身份证号码的正则表达式
            if (!Regex.IsMatch(IDNo, REGEX_ID_NO_15))
            {
                return string.Empty;
            }
            // 得到本体码，因一代身份证皆为19XX年生人，年份中增加19，组成4位
            string masterNumber = IDNo.Substring(0, 6) + "19" + IDNo.Substring(6);
            // 计算校验码
            string checkNumber = ComputeCheckNumber(masterNumber);
            // 返回本体码+校验码=完整的身份证号码
            return masterNumber + checkNumber;
        }

        /// <summary>
        /// 计算校验码 适用于18位的二代身份证号码
        /// </summary>
        /// <param name="masterNumber">本体码</param>
        /// <returns>校验码</returns>
        private static string ComputeCheckNumber(string masterNumber)
        {
            char[] masterNumberArray = masterNumber.ToCharArray();
            int sum = 0;
            for (int i = 0; i < W.Length; i++)
            {
                sum += int.Parse(masterNumberArray[i].ToString()) * W[i];
            }
            // 根据同余定理得到的校验码数组
            string[] checkNumberArray = { "1", "0", "X", "9", "8", "7", "6", "5", "4",
            "3", "2" };
            // 得到校验码
            string checkNumber = checkNumberArray[sum % 11];
            // 返回校验码
            return checkNumber;
        }

        /// <summary>
        /// 校验身份证号码的验证码
        /// </summary>
        private static bool ValidateCheckNumber(string id)
        {
            char[] IDNoArray = id.ToCharArray();
            int sum = 0;
            for (int i = 0; i < W.Length; i++)
            {
                sum += int.Parse(IDNoArray[i].ToString()) * W[i];
            }
            // 校验位是X，则表示10
            if (IDNoArray[17].Equals('X') || IDNoArray[17].Equals('x'))
            {
                sum += 10;
            }
            else
            {
                sum += int.Parse(IDNoArray[17].ToString());
            }
            // 如果除11模1，则校验通过
            return sum % 11 == 1;
        }
    }

}