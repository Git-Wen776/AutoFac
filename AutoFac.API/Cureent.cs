namespace AutoFac.API
{
    public class Cureent
    {
        public static object obj = 1;
        public static Cureent cureent;

        private string selectindex;

        public static Cureent GetCureent()
        {
            if (cureent == null)
            {
                lock (obj)
                {
                    if(cureent == null)
                        cureent = new Cureent();
                }
            }
            return cureent;
        }

        public virtual string CurrentStr()
        {
            return "woshi";
        }

        public Cureent() { }

        public Cureent(string index)
        {
            this.selectindex = index;   
        }
    }
}
