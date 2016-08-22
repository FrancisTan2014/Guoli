using Guoli.Model;

namespace Guoli.Dal
{
    public partial class LineStationsDal : BaseDal<LineStations>
    {

        protected override string TableName
        {
            get { return "LineStations"; }
        }

        protected override string PrimaryKeyName
        {
            get { return "Id"; }
        }
    }
}
