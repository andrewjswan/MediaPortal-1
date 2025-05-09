﻿#region Copyright (C) 2005-2023 Team MediaPortal

// Copyright (C) 2005-2023 Team MediaPortal
// http://www.team-mediaportal.com
// 
// MediaPortal is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// MediaPortal is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MediaPortal. If not, see <http://www.gnu.org/licenses/>.

#endregion

using System;
using System.IO;
using System.Windows.Forms;

namespace MediaPortal.DeployTool.InstallationChecks
{
  internal class TitanExtensionInstall : MPEInstall
  {

    public TitanExtensionInstall()
    {
      MpeId = "d2c4076c-f3d0-4d84-9a74-83fbbd15c940";
      MpeURL = "https://www.team-mediaportal.com/index.php?option=com_mtree&task=att_download&link_id=252&cf_id=24";
      MpeUpdateURL = "https://www.team-mediaportal.com/index.php?option=com_mtree&task=att_download&link_id=252&cf_id=52";
      MpeUpdateFile = Application.StartupPath + "\\deploy\\" + "TitanExtendedUpdate.xml";
      FileName = Application.StartupPath + "\\deploy\\" + "TitanExtended.mpe1";
    }

    public override string GetDisplayName()
    {
      return "Titan Extended" + (OnlineVersion != null ? " " + OnlineVersion.ToString() : string.Empty);
    }

    public override string GetIconName()
    {
      return "TitanExtended";
    }

    public override CheckResult CheckStatus()
    {
      CheckResult result = default(CheckResult);

      if (InstallationProperties.Instance["ConfigureMediaPortalTitanExtended"] == "0")
      {
        result.state = CheckState.SKIPPED;
        return result;
      }

      Version vMpeInstalled = GetInstalledMpeVersion();
      if (vMpeInstalled != null)
      {
        OnlineVersion = GetLatestAvailableMpeVersion();
        if (OnlineVersion != null || vMpeInstalled != null)
        {
          if (OnlineVersion != null && (vMpeInstalled >= OnlineVersion))
          {
            result.state = CheckState.INSTALLED;
          }
          else
          {
            result.needsDownload = !File.Exists(FileName);
          }
        }
        else
        {
          result.state = CheckState.VERSION_LOOKUP_FAILED;
        }
      }
      else
      {
        result.needsDownload = !File.Exists(FileName);
      }

      if (InstallationProperties.Instance["InstallType"] == "download_only")
      {
        result.state = result.needsDownload == false ? CheckState.DOWNLOADED : CheckState.NOT_DOWNLOADED;
      }

      return result;
    }

  }
}
