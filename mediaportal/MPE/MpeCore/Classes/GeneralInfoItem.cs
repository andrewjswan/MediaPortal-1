#region Copyright (C) 2005-2011 Team MediaPortal

// Copyright (C) 2005-2011 Team MediaPortal
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
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpeCore.Classes
{
  public class GeneralInfoItem
  {
    private static List<GeneralInfoItem> _ExtensionsWhiteList = null;

    public GeneralInfoItem()
    {
      Version = new VersionInfo();
      Id = Guid.NewGuid().ToString();
      ReleaseDate = DateTime.Now;
      Tags = string.Empty;
      ExtensionDescription = string.Empty;
      VersionDescription = string.Empty;
      Params = new SectionParamCollection();
      Params.Add(new SectionParam(ParamNamesConst.ICON, "", ValueTypeEnum.File,
                                  "The icon file of the package (jpg,png,bmp)"));
      Params.Add(new SectionParam(ParamNamesConst.ONLINE_ICON, "", ValueTypeEnum.String,
                                  "The icon file of the package stored online (jpg,png,bmp)"));
      Params.Add(new SectionParam(ParamNamesConst.CONFIG, "", ValueTypeEnum.Template,
                                  "The file used to configure the extension.\n If it has .exe extension the will be executed.\n If it has .dll extension it's started like MP plugin configuration."));
      Params.Add(new SectionParam(ParamNamesConst.ONLINE_SCREENSHOT, "", ValueTypeEnum.String,
                                  "Online stored screenshot urls separated by ; "));
      Params.Add(new SectionParam(ParamNamesConst.FORCE_TO_UNINSTALL_ON_UPDATE, "yes", ValueTypeEnum.Bool,
                                  "Show dialog and force to uninstall previous version when updating an extension. Should only be disabled if you are using an NSIS/MSI installer."));
    }

    public string Name { get; set; }
    public string Id { get; set; }
    public string Author { get; set; }
    public string HomePage { get; set; }
    public string ForumPage { get; set; }
    public string UpdateUrl { get; set; }
    public VersionInfo Version { get; set; }
    public string ExtensionDescription { get; set; }
    public string VersionDescription { get; set; }
    public string DevelopmentStatus { get; set; }
    public string OnlineLocation { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Tags { get; set; }
    public PlatformCompatibilityEnum PlatformCompatibility
    {
      get
      {
        if (this.TryGetPlatformCompatibilityFromList(out PlatformCompatibilityEnum compatibility))
          return compatibility;

        return this._PlatformCompatibility;
      }
      set { this._PlatformCompatibility = value; }
    } private PlatformCompatibilityEnum _PlatformCompatibility = PlatformCompatibilityEnum.x86;

    /// <summary>
    /// Gets or sets the location of packed file.
    /// </summary>
    /// <value>The location.</value>
    public string Location { get; set; }

    public SectionParamCollection Params { get; set; }

    public TagCollection TagList
    {
      get { return new TagCollection(Tags); }
    }

    private bool TryGetPlatformCompatibilityFromList(out PlatformCompatibilityEnum compatibility)
    {
      compatibility = PlatformCompatibilityEnum.x86;

      if (_ExtensionsWhiteList == null)
      {
        //Build extension list from embeded resource txt file
        try
        {
          using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MpeCore.Data.ExtensionPlatformCompatibilityList.txt"))
          {
            List<GeneralInfoItem> list = new List<GeneralInfoItem>();
            StreamReader sr = new StreamReader(stream);
            string strLine;
            while (!sr.EndOfStream)
            {
              strLine = sr.ReadLine().Trim();
              if (string.IsNullOrWhiteSpace(strLine) || strLine.StartsWith("#"))
                continue;

              //#GUID;VERSION;COMPATIBILITY;DESCRIPTION
              string[] parts = strLine.Split(';');
              if (parts.Length < 4)
                continue;

              VersionInfo version = new VersionInfo(new Version(parts[1]));

              if (list.Exists(p => p.Id.Equals(parts[0], StringComparison.CurrentCultureIgnoreCase) && p.Version == version))
                continue;

              list.Add(new GeneralInfoItem()
              {
                Id = parts[0],
                Version = version,
                PlatformCompatibility = (PlatformCompatibilityEnum)Enum.Parse(typeof(PlatformCompatibilityEnum), parts[2]),
                ExtensionDescription = parts[3]
              });

            }

            //Set the extension list
            _ExtensionsWhiteList = list;
          }

        }
        catch
        {
          return false;
        }
      }

      //Try find the extension in the whitelist
      GeneralInfoItem gi = _ExtensionsWhiteList.Find(p => p.Id.Equals(this.Id, StringComparison.CurrentCultureIgnoreCase) && p.Version == this.Version);
      if (gi != null)
      {
        compatibility = gi._PlatformCompatibility; //use private field to avoid recursion
        return true;
      }

      return false;
    }
  }
}