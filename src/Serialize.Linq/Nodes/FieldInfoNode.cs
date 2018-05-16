﻿#region Copyright
//  Copyright, Sascha Kiefer (esskar)
//  Released under LGPL License.
//  
//  License: https://raw.github.com/esskar/Serialize.Linq/master/LICENSE
//  Contributing: https://github.com/esskar/Serialize.Linq
#endregion

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using Serialize.Linq.Interfaces;
using Serialize.Linq.Internals;

namespace Serialize.Linq.Nodes
{
    #region DataContract
#if !SERIALIZE_LINQ_OPTIMIZE_SIZE
    [DataContract]
#else
    [DataContract(Name = "FI")]
#endif
#if !SILVERLIGHT && !NETSTANDARD && !WINDOWS_UWP
    [Serializable]
#endif
    #endregion
    public class FieldInfoNode : MemberNode<FieldInfo>
    {
        public FieldInfoNode() { }

        public FieldInfoNode(INodeFactory factory, FieldInfo memberInfo)
            : base(factory, memberInfo) { }

        internal override NodeKind NodeKind => NodeKind.FieldInfo;

        protected override IEnumerable<FieldInfo> GetMemberInfosForType(IExpressionContext context, Type type)
        {
            return type.GetFields();
        }
    }
}