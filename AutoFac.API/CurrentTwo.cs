namespace AutoFac.API
{
    public class CurrentTwo:Cureent
    {
        private string selectindex;

        public CurrentTwo(string index) : base(index)
        {
            selectindex = index;
        }
        public override string CurrentStr()
        {
            return selectindex;
        }
    }
}
