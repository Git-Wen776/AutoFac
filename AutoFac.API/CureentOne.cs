namespace AutoFac.API
{
    public class CureentOne:Cureent
    {
        private string selectindex;

        public CureentOne(string index) : base(index)
        {
            selectindex = index;
        }
        public override string CurrentStr()
        {
            return selectindex;
        }
    }
}
