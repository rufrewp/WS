using System;
using System.Collections.Generic;
using System.Text;

namespace TrainersSource.DomainObjects
{
    public class Trainers : DomainObject
    {
        public string Surname { get; set; }

        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Sport { get; set; }

    }
}
