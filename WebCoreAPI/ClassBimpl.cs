namespace WebCoreAPI
{
    public class ClassBimpl: IClassB
    {
        public ClassBimpl()
        {

        }

        public async Task<int> CongHaiSo(int a, int b)
        {
            return a + b;
        }
    }
}
