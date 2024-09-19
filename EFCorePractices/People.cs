using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractices
{
    public class People : IEnumerable<Person>
    {
        List<Person> personList = new List<Person>();

        public bool Add(Person person)
        {
            personList.Add(person);
            return true;
        }

        public IEnumerator<Person> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
