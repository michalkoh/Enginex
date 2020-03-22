namespace Enginex.Domain.Data
{
    public struct PageArgument
    {
        private const int DefaultPageSize = 10;

        public PageArgument(int page)
            : this(page, DefaultPageSize)
        {
        }

        public PageArgument(int page, int size)
        {
            Page = page;
            Size = size;
        }

        public int Size { get; }

        public int Page { get; }
    }
}
