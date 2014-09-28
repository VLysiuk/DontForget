using System.Collections.Generic;

namespace DontForget.Data
{
    public class DontForgetList
    {
        public DontForgetList(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public IList<string> Items { get; private set; }
    }
}
