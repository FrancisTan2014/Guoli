using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Guoli.Model;

namespace Guoli.Admin.Models
{
    /// <summary>
    /// 手账记录上传数据模型
    /// </summary>
    public class DrivePlanUploadModel
    {
        public DriveRecords DriveRecords { get; set; }
        public List<DriveSignPoint> DriveSignPoints { get; set; }
        public List<TrainFormation> TrainFormations { get; set; }
        public List<DriveTrainNoAndLine> DriveTrainNoAndLines { get; set; }
    }
}