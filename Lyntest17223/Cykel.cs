using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyntest17223
{
    public class Cykel : IComparable<Cykel>
    {
        private int _stelnr;
        private string _model;
        private int _aar;

        public int Stelnr
        {
            get { return _stelnr; }
            set { _stelnr = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public int Aar
        {
            get { return _aar; }
            set { _aar = value; }
        }

        public Cykel(int stelnr, string model, int aar)
        {
            _stelnr = stelnr;
            _model = model;
            _aar = aar;
        }

        public override string ToString()
        {
            return $"Stelnr:{_stelnr} model:{_model},år:{_aar}";
        }

        public int CompareTo(Cykel? other)
        {
            if (_stelnr > other.Stelnr)
                return 1;
            else if (other.Stelnr > _stelnr)
                return -1;
            else return 0;
        }

    }
}
