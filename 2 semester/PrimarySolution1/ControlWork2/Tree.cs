
namespace ControlWork2
{
    public class BinTree
    {
        public BinTree(int data = default(int)) 
        {
            this.Data = data;
        }

        public void Add(int data)
        {
            if (this.Data == default(int))
            {
                this.Data = data;
            }
            if (this.Left == null)
            {
                this.Left = new BinTree(data);
            }
            else if (this.Right == null)
            {
                this.Right = new BinTree(data);
            }
            else
            {
                this.Left.Add(data);
            }
        }

        public void Remove(int data)
        {

        }

        public int Data { get; private set; }
        public BinTree Left { get; private set; }
        public BinTree Right { get; private set; }
    }
}
