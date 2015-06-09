﻿using System.Collections;
using System.Collections.Generic;

namespace Serialize.Linq.Nodes
{
    public abstract class NodeList<TNode> : Node, IEnumerable<TNode> where TNode : Node
    {
        private readonly List<TNode> _list;

        protected NodeList(NodeKind nodeKind)
            : base(nodeKind)
        {
            _list = new List<TNode>();
        }

        public void Add(TNode node)
        {
            _list.Add(node);
        }

        public void AddRange(IEnumerable<TNode> nodes)
        {
            _list.AddRange(nodes);
        }

        public IEnumerator<TNode> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
