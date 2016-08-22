using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guoli.Model
{
    public partial class LineStations
    {
        private int _id;
        private int _lineid;
        private int _stationid;
        private string _stationname;
        private int _sort;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int LineId
        {
            get { return _lineid; }
            set { _lineid = value; }
        }

        public int StationId
        {
            get { return _stationid; }
            set { _stationid = value; }
        }

        public string StationName
        {
            get { return _stationname; }
            set { _stationname = value; }
        }

        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
    }
}
