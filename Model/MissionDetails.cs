﻿
namespace Kcsar.Database.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class MissionDetails : ModelObject
    {
        public string Clouds { get; set; }
        public double? TempLow { get; set; }
        public double? TempHigh { get; set; }
        public double? WindLow { get; set; }
        public double? WindHigh { get; set; }
        public double? Visibility { get; set; }
        public int? RainType { get; set; }
        public double? RainInches { get; set; }
        public int? SnowType { get; set; }
        public double? SnowInches { get; set; }
        public int? Terrain { get; set; }
        public int? GroundCoverDensity { get; set; }
        public int? GroundCoverHeight { get; set; }
        public int? WaterType { get; set; }
        public int? TimberType { get; set; }
        public int? ElevationLow { get; set; }
        public int? ElevationHigh { get; set; }
        public string Tactics { get; set; }
        public string CluesMethod { get; set; }
        public string TerminatedReason { get; set; }
        public bool? Debrief { get; set; }
        public bool? Cisd { get; set; }
        public string Comments { get; set; }
        public string EquipmentNotes { get; set; }
        public int? Topography { get; set; }
        public virtual Mission Mission { get; set; }
        public virtual Member Person { get; set; }

        public override string ToString()
        {
            return string.Format("Details");
        }

        public override string GetReportHtml()
        {
            //if (this.EntityState == System.Data.EntityState.Modified || this.EntityState == System.Data.EntityState.Unchanged)
            //{
            //    if (!this.MissionReference.IsLoaded)
            //    {
            //        this.MissionReference.Load();
            //    }
            //}
            return string.Format("Details of [<b>{0}</b>]", this.Mission.Title);
        }

        #region IValidatedEntity Members

        public override bool Validate()
        {
            errors.Clear();

            return (errors.Count == 0);
        }

        #endregion
    }
}