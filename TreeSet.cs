
public class TreeSet<T>
{

    public class TreeSetNode<N>
    {

        public TreeSetNode<N> Parent;
        public TreeSetNode<N>[] Children;
        public N Value;
        public bool Filled = false;

        private int FilledCount = 0;

        public TreeSetNode(N val, int order)
        {
            Value = val;
            Children = new TreeSetNode<N>[order];
        }

        public void AddChild(TreeSetNode<N> child)
        {
            Children[FilledCount++] = child;
            if (FilledCount == Children.Length) Filled = true;
        }

    }

    public TreeSetNode<T> First;
    public TreeSetNode<T> Last;
    public int Order;
    public int Count = 0;

    private byte[] Remainders = new byte[32];

    public TreeSet(int order = 2)
    {
        Order = order;
    }

    public TreeSetNode<T> this[int idx]
    {
        get
        {
            if (idx >= Count) return null;
            if (idx == 0) return First;
            idx++;
            int i = 0;
            while (idx != 1)
            {
                Remainders[i++] = (byte)(idx % Order);
                idx /= Order;
            }
            i--;
            TreeSetNode<T> node = First;
            for (; i >= 0; i--) 
            {
                node = node.Children[Remainders[i]];
            }
            return node;
        }
    }

    public TreeSetNode<T> ParentOf(int idx)
    {
        if (idx > Count) return null;
        if (idx == 0) return null;
        idx++;
        int i = 0;
        while (idx != 1)
        {
            Remainders[i++] = (byte)(idx % Order);
            idx /= Order;
        }
        i--;
        TreeSetNode<T> node = First;
        for (; i >= 1; i--)
        {
            node = node.Children[Remainders[i]];
        }
        return node;
    }

    public void Add(T val)
    {
        Last = new TreeSetNode<T>(val, Order);
        if (Count == 0)
        {
            First = Last;
        }
        else
        {
            TreeSetNode<T> parent = ParentOf(Count);
            parent.AddChild(Last);
        }
        Count++;
    }

    public void RemoveAt(int idx)
    {
        if (idx >= Count) return;
        if (Count == 1)
        {
            First = Last = null;
            return;
        }
        TreeSetNode<T> node = this[idx];
        node.Value = Last.Value;
        if (Last.Parent != null) Last.Parent.Children[(Count - 2) % Order] = null;
        Last = this[Count - 2];
        Count--;
    }

}
