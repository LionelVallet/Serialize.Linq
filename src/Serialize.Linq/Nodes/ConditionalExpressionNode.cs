﻿#region Copyright
//  Copyright, Sascha Kiefer (esskar)
//  Released under LGPL License.
//  
//  License: https://raw.github.com/esskar/Serialize.Linq/master/LICENSE
//  Contributing: https://github.com/esskar/Serialize.Linq
#endregion

using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace Serialize.Linq.Nodes
{
    #region DataContract
#if !SERIALIZE_LINQ_OPTIMIZE_SIZE
    [DataContract]
#else
    [DataContract(Name = "IF")]   
#endif
#if !SILVERLIGHT
    [Serializable]
#endif
    #endregion
    public class ConditionalExpressionNode : ExpressionNode
    {
        public ConditionalExpressionNode()
            : base(NodeKind.ConditionalExpression) { }

        #region DataMember
#if !SERIALIZE_LINQ_OPTIMIZE_SIZE
        [DataMember(EmitDefaultValue = false)]
#else
        [DataMember(EmitDefaultValue = false, Name = "IFF")]
#endif
        #endregion
        public ExpressionNode IfFalse { get; set; }

        #region DataMember
#if !SERIALIZE_LINQ_OPTIMIZE_SIZE
        [DataMember(EmitDefaultValue = false)]
#else
        [DataMember(EmitDefaultValue = false, Name = "IFT")]
#endif
        #endregion
        public ExpressionNode IfTrue { get; set; }

        #region DataMember
#if !SERIALIZE_LINQ_OPTIMIZE_SIZE
        [DataMember(EmitDefaultValue = false)]
#else
        [DataMember(EmitDefaultValue = false, Name = "C")]
#endif
        #endregion
        public ExpressionNode Test { get; set; }

        /// <summary>
        /// Converts this instance to an expression.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override Expression ToExpression(ExpressionContext context)
        {
            return Expression.Condition(this.Test.ToExpression(context), this.IfTrue.ToExpression(context), this.IfFalse.ToExpression(context));
        }
    }
}
