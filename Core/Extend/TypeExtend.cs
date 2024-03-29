﻿/***************************************************
* Copyright(C) 2021 by xinansky                    *
* All Rights Reserved By Author lihongliu.         *
* Author:            XiNan                         *
* Email:             1398581458@qq.com             *
* Version:           0.1                           *
* UnityVersion:      2020.3.12f1c1                 *
* Date:              2021-08-31                    *
* Nowtime:           21:38:22                      *
* Description:                                     *
* History:                                         *
***************************************************/

namespace Framework.Extend
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// 类扩展
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/system.type?view=net-5.0"/>
    public static class TypeExtend
    {
        /// <summary> 
        /// 类名
        /// </summary>
        public static string GETName<T>(this T o) where T : Type
        {
            return typeof(T).Name;
        }

        /// <summary> 
        /// 命名空间 + 类名 
        /// </summary>
        public static string GETFullName<T>(this T o) where T : Type
        {
            return typeof(T).FullName;
        }

        /// <summary> 
        /// 获取类的 命名空间
        /// </summary>
        public static string GETNamespace<T>(this T o) where T : Type
        {
            return typeof(T).Namespace;
        }

        /// <summary> 
        /// 获取程序集
        /// </summary>
        public static Assembly GETAssembly<T>(this T o) where T : Type
        {
            return typeof(T).Assembly;
        }

        /// <summary> 
        /// 获取类型的程序集限定名
        /// </summary>
        public static string GETAssemblyQualifiedName<T>(this T o) where T : Type
        {
            return typeof(T).AssemblyQualifiedName;
        }

        /// <summary> 
        /// 获取类型的属性类型
        /// </summary>
        public static TypeAttributes GETAttributes<T>(this T o) where T : Type
        {
            return typeof(T).Attributes;
        }

        /// <summary> 
        /// 获取类的基类
        /// </summary>
        public static Type GETBaseType<T>(this T o) where T : Type
        {
            return typeof(T).BaseType;
        }

        /// <summary> 
        /// 是否包含泛型参数
        /// </summary>
        public static bool ISContainsGenericParameters<T>(this T o) where T : Type
        {
            return typeof(T).ContainsGenericParameters;
        }

        /// <summary> 
        /// 获取类的自定义特性
        /// </summary>
        public static IEnumerable<CustomAttributeData> GETCustomAttributes<T>(this T o) where T : Type
        {
            return typeof(T).CustomAttributes;
        }

        /// <summary> 
        /// 获取类的方法库
        /// </summary>
        public static MethodBase GETDeclaringMethod<T>(this T o) where T : Type
        {
            return typeof(T).DeclaringMethod;
        }

        /// <summary> 
        /// 获取类的声明类型
        /// </summary>
        public static Type GETDeclaringType<T>(this T o) where T : Type
        {
            return typeof(T).DeclaringType;
        }

        /// <summary> 
        /// 获取类的当前泛型类型参数的协方差和特殊约束的 GenericParameterAttributes值的按位组合。
        /// </summary>
        public static GenericParameterAttributes GETGenericParameterAttributes<T>(this T o) where T : Type
        {
            return typeof(T).GenericParameterAttributes;
        }

        /// <summary> 
        /// 获取类当前的 泛型参数位置
        /// </summary>
        public static int GETGenericParameterPosition<T>(this T o) where T : Type
        {
            return typeof(T).GenericParameterPosition;
        }

        /// <summary> 
        /// 获取类当前的 泛型类型参数
        /// </summary>
        public static Type[] GETGenericTypeArguments<T>(this T o) where T : Type
        {
            return typeof(T).GenericTypeArguments;
        }

        /// <summary> 
        /// 获取类的 全部构造函数
        /// </summary>
        public static ConstructorInfo[] GETConstructors<T>(this T o) where T : Type
        {
            return typeof(T).GetConstructors();
        }

        /// <summary> 
        /// 获取在数组中的维度
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/system.type.getarrayrank?view=net-5.0"/>
        public static int GETArrayRank<T>(this T o) where T : Type
        {
            return typeof(T).GetArrayRank();
        }

        /// <summary> 
        /// 获取类的 构造函数
        /// </summary>
        public static ConstructorInfo GETArrayRank<T>(this T o, BindingFlags binding, Binder binder, CallingConventions calling, Type[] types, ParameterModifier[] modifier) where T : Type
        {
            return typeof(T).GetConstructor(binding, binder, calling, types, modifier);
        }

        /// <summary> 
        /// 获取类当前的 自定义属性
        /// </summary>
        public static object[] GETGenericTypeArguments<T>(this T o, bool inherit) where T : Type
        {
            return typeof(T).GetCustomAttributes(inherit);
        }

        /// <summary> 
        /// 获取类当前的 自定义属性
        /// </summary>
        public static object[] GETGenericTypeArguments<T>(this T o, Type attributeType, bool inherit) where T : Type
        {
            return typeof(T).GetCustomAttributes(attributeType, inherit);
        }

        /// <summary> 
        /// 获取类当前的 获取自定义属性数据
        /// </summary>
        public static IList<CustomAttributeData> GETCustomAttributesDatas<T>(this T o) where T : Type
        {
            return typeof(T).GetCustomAttributesData();
        }

        /// <summary> 
        /// 获取类当前的 默认成员信息
        /// </summary>
        public static MemberInfo[] GETDefaultMembers<T>(this T o) where T : Type
        {
            return typeof(T).GetDefaultMembers();
        }

        /// <summary> 
        /// 获取类当前的 元素类型
        /// </summary>
        public static Type GETElementType<T>(this T o) where T : Type
        {
            return typeof(T).GetElementType();
        }

        /* FieldInfo.Name = 属性名
         * DeclaringType  = 声明类型
         * IsPublic       = 是否为公开的
         * MemberType     = 成员类型     (字段)
         * FieldType      = 字段类型     (string)
         * IsFamily       = ??????
         * ReflectedType  = 反射类型     (string)
         * IsAssembly     = ??????
         * Module         = 程序集
         */

        /// <summary> 
        /// 获取所有变量
        /// </summary>
        public static FieldInfo[] GETFieldInfo<T>(this T myType)
        {
            return typeof(T).GetFields();
        }

        /// <summary> 
        /// 获取所有变量
        /// </summary>
        public static FieldInfo[] GETFieldInfo<T>(this T myType, BindingFlags flags)
        {
            return typeof(T).GetFields(flags);
        }

        /// <summary> 
        /// 重置类数据
        /// </summary>
        public static T Reset<T>(this T myType, BindingFlags flags)
        {
            var myFieldInfo = typeof(T).GetFields(flags);
            foreach (var item in myFieldInfo)
            {
                item.SetValue(myType, default);
            }
            return myType;
        }

        /// <summary> 
        /// 重置类数据
        /// </summary>
        public static T Reset<T>(this T myType)
        {
            var myFieldInfo = typeof(T).GetFields();
            foreach (var item in myFieldInfo)
            {
                item.SetValue(myType, default);
            }
            return myType;
        }

        /// <summary> 
        /// 获取所有方法
        /// </summary>
        public static MethodInfo[] GetMethodInfo<T>(this T myType)
        {
            return typeof(T).GetMethods();
        }

        /// <summary> 
        /// 获取所有方法
        /// </summary>
        public static MethodInfo[] GetMethodInfo<T>(this T myType, BindingFlags flags)
        {
            return typeof(T).GetMethods(flags);
        }
    }
}