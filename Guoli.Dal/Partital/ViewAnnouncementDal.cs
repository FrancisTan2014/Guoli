using Guoli.Model;

namespace Guoli.Dal
{
    public partial class ViewAnnouncementDal : BaseDal<ViewAnnouncement>
    {
        /// <summary>
        /// 在派生类中重写时，表示当前操作的表名称
        /// </summary>
        protected override string TableName => nameof(ViewAnnouncement);

        /// <summary>
        /// 在派生类中重写时，表示当前表的主键名称
        /// </summary>
        protected override string PrimaryKeyName => nameof(ViewAnnouncement.Id);
    }
}
