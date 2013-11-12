using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A1020_Hardware.Sample;


namespace A1020_Hardware
{
    class Program
    {

        static void Main(string[] args)
        {

            // 进程信息.
            //Test.ShowHardwareInfo("Win32_Process");


            // BIOS 信息.
            //Test.ShowHardwareInfo("Win32_BIOS");


            // 硬盘信息.
            // Test.ShowHardwareInfo("Win32_DiskDrive");


            // 当前计算机的基本信息.
            // Test.ShowHardwareInfo("Win32_ComputerSystem");



            // 操作系统基本信息.
            // 包含：
            //    引导区 (BootDevice)
            //    编译版本号(BuildNumber)
            //    名称 (Name)
            //    代码集 (CodeSet)
            //    标题 (Caption)
            //    国家代码 (CountryCode)
            //    所在时区分钟 (CurrentTimeZone)
            //    计算机名(CSName)
            //    语言 (MUILanguages)
            //    体系构架 (OSArchitecture)
            //    国家代码 (OSLanguage).
            //    系统设备 (SystemDevice)
            //    系统目录 (SystemDirectory)
            //    系统盘 (SystemDrive)
            //    版本 (Version) 
            //    SP版本 (CSDVersion)
            //    Windows目录 (WindowsDirectory)
            // Test.ShowHardwareInfo("Win32_OperatingSystem");



            // 物理内存.
            // Test.ShowHardwareInfo("Win32_PhysicalMemory");


            // 计算机上安装的软件 （此过程执行时间非常的长...）
            // Test.ShowHardwareInfo("Win32_Product");

            // （此过程执行时间非常的长...）
            // Test.ShowHardwareInfo("Win32_Property");

            // 查询计算机的 服务.
            //Test.ShowHardwareInfo("Win32_Service");


            // 查询系统用户.
            // Test.ShowHardwareInfo("Win32_SystemUsers");


            // 查询系统基本用户信息.
            // Test.ShowHardwareInfo("Win32_UserAccount");










            // 查询操作系统的 语言.
            Console.WriteLine (Test.GetHardwareInfoValue("Win32_OperatingSystem", "OSLanguage"));



            /*
             * 结果参考:

            http://msdn.microsoft.com/ja-jp/library/aa394239(VS.85).aspx
             
            Value Meaning
            1 (0x1)  Arabic
            4 (0x4)  Chinese (Simplified)– China
            9 (0x9)  English
            1025 (0x401)  Arabic – Saudi Arabia
            1026 (0x402)  Bulgarian
            1027 (0x403)  Catalan
            1028 (0x404)  Chinese (Traditional) – Taiwan
            1029 (0x405)  Czech
            1030 (0x406)  Danish
            1031 (0x407)  German – Germany
            1032 (0x408)  Greek
            1033 (0x409)  English – United States
            1034 (0x40A)  Spanish – Traditional Sort
            1035 (0x40B)  Finnish
            1036 (0x40C)  French – France
            1037 (0x40D)  Hebrew
            1038 (0x40E)  Hungarian
            1039 (0x40F)  Icelandic
            1040 (0x410)  Italian – Italy
            1041 (0x411)  Japanese
            1042 (0x412)  Korean
            1043 (0x413)  Dutch – Netherlands
            1044 (0x414)  Norwegian – Bokmal
            1045 (0x415)  Polish
            1046 (0x416)  Portuguese – Brazil
            1047 (0x417)  Rhaeto-Romanic
            1048 (0x418)  Romanian
            1049 (0x419)  Russian
            1050 (0x41A)  Croatian
            1051 (0x41B)  Slovak
            1052 (0x41C)  Albanian
            1053 (0x41D)  Swedish
            1054 (0x41E)  Thai
            1055 (0x41F)  Turkish
            1056 (0x420)  Urdu
            1057 (0x421)  Indonesian
            1058 (0x422)  Ukrainian
            1059 (0x423)  Belarusian
            1060 (0x424)  Slovenian
            1061 (0x425)  Estonian
            1062 (0x426)  Latvian
            1063 (0x427)  Lithuanian
            1065 (0x429)  Persian
            1066 (0x42A)  Vietnamese
            1069 (0x42D)  Basque (Basque) – Basque
            1070 (0x42E)  Serbian
            1071 (0x42F)  Macedonian (FYROM)
            1072 (0x430)  Sutu
            1073 (0x431)  Tsonga
            1074 (0x432)  Tswana
            1076 (0x434)  Xhosa
            1077 (0x435)  Zulu
            1078 (0x436)  Afrikaans
            1080 (0x438)  Faeroese
            1081 (0x439)  Hindi
            1082 (0x43A)  Maltese
            1084 (0x43C)  Scottish Gaelic (United Kingdom)
            1085 (0x43D)  Yiddish
            1086 (0x43E)  Malay – Malaysia
            2049 (0x801)  Arabic – Iraq
            2052 (0x804)  Chinese (Simplified) – PRC
            2055 (0x807)  German – Switzerland
            2057 (0x809)  English – United Kingdom
            2058 (0x80A)  Spanish – Mexico
            2060 (0x80C)  French – Belgium
            2064 (0x810)  Italian – Switzerland
            2067 (0x813)  Dutch – Belgium
            2068 (0x814)  Norwegian – Nynorsk
            2070 (0x816)  Portuguese – Portugal
            2072 (0x818)  Romanian – Moldova
            2073 (0x819)  Russian – Moldova
            2074 (0x81A)  Serbian – Latin
            2077 (0x81D)  Swedish – Finland
            3073 (0xC01)  Arabic – Egypt
            3076 (0xC04)  Chinese (Traditional) – Hong Kong SAR
            3079 (0xC07)  German – Austria
            3081 (0xC09)  English – Australia
            3082 (0xC0A)  Spanish – International Sort
            3084 (0xC0C)  French – Canada
            3098 (0xC1A)  Serbian – Cyrillic
            4097 (0x1001)  Arabic – Libya
            4100 (0x1004)  Chinese (Simplified) – Singapore
            4103 (0x1007)  German – Luxembourg
            4105 (0x1009)  English – Canada
            4106 (0x100A)  Spanish – Guatemala
            4108 (0x100C)  French – Switzerland
            5121 (0x1401)  Arabic – Algeria
            5127 (0x1407)  German – Liechtenstein
            5129 (0x1409)  English – New Zealand
            5130 (0x140A)  Spanish – Costa Rica
            5132 (0x140C)  French – Luxembourg
            6145 (0x1801)  Arabic – Morocco
            6153 (0x1809)  English – Ireland
            6154 (0x180A)  Spanish – Panama
            7169 (0x1C01)  Arabic – Tunisia
            7177 (0x1C09)  English – South Africa
            7178 (0x1C0A)  Spanish – Dominican Republic
            8193 (0x2001)  Arabic – Oman
            8201 (0x2009)  English – Jamaica
            8202 (0x200A)  Spanish – Venezuela
            9217 (0x2401)  Arabic – Yemen
            9226 (0x240A)  Spanish – Colombia
            10241 (0x2801)  Arabic – Syria
            10249 (0x2809)  English – Belize
            10250 (0x280A)  Spanish – Peru
            11265 (0x2C01)  Arabic – Jordan
            11273 (0x2C09)  English – Trinidad
            11274 (0x2C0A)  Spanish – Argentina
            12289 (0x3001)  Arabic – Lebanon
            12298 (0x300A)  Spanish – Ecuador
            13313 (0x3401)  Arabic – Kuwait
            13322 (0x340A)  Spanish – Chile
            14337 (0x3801)  Arabic – U.A.E.
            14346 (0x380A)  Spanish – Uruguay
            15361 (0x3C01)  Arabic – Bahrain
            15370 (0x3C0A)  Spanish – Paraguay
            16385 (0x4001)  Arabic – Qatar
            16394 (0x400A)  Spanish – Bolivia
            17418 (0x440A)  Spanish – El Salvador
            18442 (0x480A)  Spanish – Honduras
            19466 (0x4C0A)  Spanish – Nicaragua
            20490 (0x500A)  Spanish – Puerto Rico

            */






            /*  
             * 可用参数：
 
            Win32_1394Controller
            Win32_1394ControllerDevice
            Win32_Account
            Win32_AccountSID
            Win32_ACE
            Win32_ActionCheck
            Win32_AllocatedResource
            Win32_ApplicationCommandLine
            Win32_ApplicationService
            Win32_AssociatedBattery
            Win32_AssociatedProcessorMemory
            Win32_BaseBoard
            Win32_BaseService
            Win32_Battery
            Win32_Binary
            Win32_BindImageAction
            Win32_BIOS
            Win32_BootConfiguration
            Win32_Bus
            Win32_CacheMemory
            Win32_CDROMDrive
            Win32_CheckCheck
            Win32_CIMLogicalDeviceCIMDataFile
            Win32_ClassicCOMApplicationClasses
            Win32_ClassicCOMClass
            Win32_ClassicCOMClassSetting
            Win32_ClassicCOMClassSettings
            Win32_ClassInfoAction
            Win32_ClientApplicationSetting
            Win32_CodecFile
            Win32_COMApplication
            Win32_COMApplicationClasses
            Win32_COMApplicationSettings
            Win32_COMClass
            Win32_ComClassAutoEmulator
            Win32_ComClassEmulator
            Win32_CommandLineAccess
            Win32_ComponentCategory
            Win32_ComputerSystem
            Win32_ComputerSystemProcessor
            Win32_ComputerSystemProduct
            Win32_COMSetting
            Win32_Condition
            Win32_CreateFolderAction
            Win32_CurrentProbe
            Win32_DCOMApplication
            Win32_DCOMApplicationAccessAllowedSetting
            Win32_DCOMApplicationLaunchAllowedSetting
            Win32_DCOMApplicationSetting
            Win32_DependentService
            Win32_Desktop
            Win32_DesktopMonitor
            Win32_DeviceBus
            Win32_DeviceMemoryAddress
            Win32_DeviceSettings
            Win32_Directory
            Win32_DirectorySpecification
            Win32_DiskDrive
            Win32_DiskDriveToDiskPartition
            Win32_DiskPartition
            Win32_DisplayConfiguration
            Win32_DisplayControllerConfiguration
            Win32_DMAChannel
            Win32_DriverVXD
            Win32_DuplicateFileAction
            Win32_Environment
            Win32_EnvironmentSpecification
            Win32_ExtensionInfoAction
            Win32_Fan
            Win32_FileSpecification
            Win32_FloppyController
            Win32_FloppyDrive
            Win32_FontInfoAction
            Win32_Group
            Win32_GroupUser
            Win32_HeatPipe
            Win32_IDEController
            Win32_IDEControllerDevice
            Win32_ImplementedCategory
            Win32_InfraredDevice
            Win32_IniFileSpecification
            Win32_InstalledSoftwareElement
            Win32_IRQResource
            Win32_Keyboard
            Win32_LaunchCondition
            Win32_LoadOrderGroup
            Win32_LoadOrderGroupServiceDependencies
            Win32_LoadOrderGroupServiceMembers
            Win32_LogicalDisk
            Win32_LogicalDiskRootDirectory
            Win32_LogicalDiskToPartition
            Win32_LogicalFileAccess
            Win32_LogicalFileAuditing
            Win32_LogicalFileGroup
            Win32_LogicalFileOwner
            Win32_LogicalFileSecuritySetting
            Win32_LogicalMemoryConfiguration
            Win32_LogicalProgramGroup
            Win32_LogicalProgramGroupDirectory
            Win32_LogicalProgramGroupItem
            Win32_LogicalProgramGroupItemDataFile
            Win32_LogicalShareAccess
            Win32_LogicalShareAuditing
            Win32_LogicalShareSecuritySetting
            Win32_ManagedSystemElementResource
            Win32_MemoryArray
            Win32_MemoryArrayLocation
            Win32_MemoryDevice
            Win32_MemoryDeviceArray
            Win32_MemoryDeviceLocation
            Win32_MethodParameterClass
            Win32_MIMEInfoAction
            Win32_MotherboardDevice
            Win32_MoveFileAction
            Win32_MSIResource
            Win32_NetworkAdapter
            Win32_NetworkAdapterConfiguration
            Win32_NetworkAdapterSetting
            Win32_NetworkClient
            Win32_NetworkConnection
            Win32_NetworkLoginProfile
            Win32_NetworkProtocol
            Win32_NTEventlogFile
            Win32_NTLogEvent
            Win32_NTLogEventComputer
            Win32_NTLogEventLog
            Win32_NTLogEventUser
            Win32_ODBCAttribute
            Win32_ODBCDataSourceAttribute
            Win32_ODBCDataSourceSpecification
            Win32_ODBCDriverAttribute
            Win32_ODBCDriverSoftwareElement
            Win32_ODBCDriverSpecification
            Win32_ODBCSourceAttribute
            Win32_ODBCTranslatorSpecification
            Win32_OnBoardDevice
            Win32_OperatingSystem
            Win32_OperatingSystemQFE
            Win32_OSRecoveryConfiguration
            Win32_PageFile
            Win32_PageFileElementSetting
            Win32_PageFileSetting
            Win32_PageFileUsage
            Win32_ParallelPort
            Win32_Patch
            Win32_PatchFile
            Win32_PatchPackage
            Win32_PCMCIAController
            Win32_Perf
            Win32_PerfRawData
            Win32_PerfRawData_ASP_ActiveServerPages
            Win32_PerfRawData_ASPNET_114322_ASPNETAppsv114322
            Win32_PerfRawData_ASPNET_114322_ASPNETv114322
            Win32_PerfRawData_ASPNET_ASPNET
            Win32_PerfRawData_ASPNET_ASPNETApplications
            Win32_PerfRawData_IAS_IASAccountingClients
            Win32_PerfRawData_IAS_IASAccountingServer
            Win32_PerfRawData_IAS_IASAuthenticationClients
            Win32_PerfRawData_IAS_IASAuthenticationServer
            Win32_PerfRawData_InetInfo_InternetInformationServicesGlobal
            Win32_PerfRawData_MSDTC_DistributedTransactionCoordinator
            Win32_PerfRawData_MSFTPSVC_FTPService
            Win32_PerfRawData_MSSQLSERVER_SQLServerAccessMethods
            Win32_PerfRawData_MSSQLSERVER_SQLServerBackupDevice
            Win32_PerfRawData_MSSQLSERVER_SQLServerBufferManager
            Win32_PerfRawData_MSSQLSERVER_SQLServerBufferPartition
            Win32_PerfRawData_MSSQLSERVER_SQLServerCacheManager
            Win32_PerfRawData_MSSQLSERVER_SQLServerDatabases
            Win32_PerfRawData_MSSQLSERVER_SQLServerGeneralStatistics
            Win32_PerfRawData_MSSQLSERVER_SQLServerLatches
            Win32_PerfRawData_MSSQLSERVER_SQLServerLocks
            Win32_PerfRawData_MSSQLSERVER_SQLServerMemoryManager
            Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationAgents
            Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationDist
            Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationLogreader
            Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationMerge
            Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationSnapshot
            Win32_PerfRawData_MSSQLSERVER_SQLServerSQLStatistics
            Win32_PerfRawData_MSSQLSERVER_SQLServerUserSettable
            Win32_PerfRawData_NETFramework_NETCLRExceptions
            Win32_PerfRawData_NETFramework_NETCLRInterop
            Win32_PerfRawData_NETFramework_NETCLRJit
            Win32_PerfRawData_NETFramework_NETCLRLoading
            Win32_PerfRawData_NETFramework_NETCLRLocksAndThreads
            Win32_PerfRawData_NETFramework_NETCLRMemory
            Win32_PerfRawData_NETFramework_NETCLRRemoting
            Win32_PerfRawData_NETFramework_NETCLRSecurity
            Win32_PerfRawData_Outlook_Outlook
            Win32_PerfRawData_PerfDisk_PhysicalDisk
            Win32_PerfRawData_PerfNet_Browser
            Win32_PerfRawData_PerfNet_Redirector
            Win32_PerfRawData_PerfNet_Server
            Win32_PerfRawData_PerfNet_ServerWorkQueues
            Win32_PerfRawData_PerfOS_Cache
            Win32_PerfRawData_PerfOS_Memory
            Win32_PerfRawData_PerfOS_Objects
            Win32_PerfRawData_PerfOS_PagingFile
            Win32_PerfRawData_PerfOS_Processor
            Win32_PerfRawData_PerfOS_System
            Win32_PerfRawData_PerfProc_FullImage_Costly
            Win32_PerfRawData_PerfProc_Image_Costly
            Win32_PerfRawData_PerfProc_JobObject
            Win32_PerfRawData_PerfProc_JobObjectDetails
            Win32_PerfRawData_PerfProc_Process
            Win32_PerfRawData_PerfProc_ProcessAddressSpace_Costly
            Win32_PerfRawData_PerfProc_Thread
            Win32_PerfRawData_PerfProc_ThreadDetails_Costly
            Win32_PerfRawData_RemoteAccess_RASPort
            Win32_PerfRawData_RemoteAccess_RASTotal
            Win32_PerfRawData_RSVP_ACSPerRSVPService
            Win32_PerfRawData_Spooler_PrintQueue
            Win32_PerfRawData_TapiSrv_Telephony
            Win32_PerfRawData_Tcpip_ICMP
            Win32_PerfRawData_Tcpip_IP
            Win32_PerfRawData_Tcpip_NBTConnection
            Win32_PerfRawData_Tcpip_NetworkInterface
            Win32_PerfRawData_Tcpip_TCP
            Win32_PerfRawData_Tcpip_UDP
            Win32_PerfRawData_W3SVC_WebService
            Win32_PhysicalMemory
            Win32_PhysicalMemoryArray
            Win32_PhysicalMemoryLocation
            Win32_PNPAllocatedResource
            Win32_PnPDevice
            Win32_PnPEntity
            Win32_PointingDevice
            Win32_PortableBattery
            Win32_PortConnector
            Win32_PortResource
            Win32_POTSModem
            Win32_POTSModemToSerialPort
            Win32_PowerManagementEvent
            Win32_Printer
            Win32_PrinterConfiguration
            Win32_PrinterController
            Win32_PrinterDriverDll
            Win32_PrinterSetting
            Win32_PrinterShare
            Win32_PrintJob
            Win32_PrivilegesStatus
            Win32_Process
            Win32_Processor
            Win32_ProcessStartup
            Win32_Product
            Win32_ProductCheck
            Win32_ProductResource
            Win32_ProductSoftwareFeatures
            Win32_ProgIDSpecification
            Win32_ProgramGroup
            Win32_ProgramGroupContents
            Win32_ProgramGroupOrItem
            Win32_Property
            Win32_ProtocolBinding
            Win32_PublishComponentAction
            Win32_QuickFixEngineering
            Win32_Refrigeration
            Win32_Registry
            Win32_RegistryAction
            Win32_RemoveFileAction
            Win32_RemoveIniAction
            Win32_ReserveCost
            Win32_ScheduledJob
            Win32_SCSIController
            Win32_SCSIControllerDevice
            Win32_SecurityDescriptor
            Win32_SecuritySetting
            Win32_SecuritySettingAccess
            Win32_SecuritySettingAuditing
            Win32_SecuritySettingGroup
            Win32_SecuritySettingOfLogicalFile
            Win32_SecuritySettingOfLogicalShare
            Win32_SecuritySettingOfObject
            Win32_SecuritySettingOwner
            Win32_SelfRegModuleAction
            Win32_SerialPort
            Win32_SerialPortConfiguration
            Win32_SerialPortSetting
            Win32_Service
            Win32_ServiceControl
            Win32_ServiceSpecification
            Win32_ServiceSpecificationService
            Win32_SettingCheck
            Win32_Share
            Win32_ShareToDirectory
            Win32_ShortcutAction
            Win32_ShortcutFile
            Win32_ShortcutSAP
            Win32_SID
            Win32_SMBIOSMemory
            Win32_SoftwareElement
            Win32_SoftwareElementAction
            Win32_SoftwareElementCheck
            Win32_SoftwareElementCondition
            Win32_SoftwareElementResource
            Win32_SoftwareFeature
            Win32_SoftwareFeatureAction
            Win32_SoftwareFeatureCheck
            Win32_SoftwareFeatureParent
            Win32_SoftwareFeatureSoftwareElements
            Win32_SoundDevice
            Win32_StartupCommand
            Win32_SubDirectory
            Win32_SystemAccount
            Win32_SystemBIOS
            Win32_SystemBootConfiguration
            Win32_SystemDesktop
            Win32_SystemDevices
            Win32_SystemDriver
            Win32_SystemDriverPNPEntity
            Win32_SystemEnclosure
            Win32_SystemLoadOrderGroups
            Win32_SystemLogicalMemoryConfiguration
            Win32_SystemMemoryResource
            Win32_SystemNetworkConnections
            Win32_SystemOperatingSystem
            Win32_SystemPartitions
            Win32_SystemProcesses
            Win32_SystemProgramGroups
            Win32_SystemResources
            Win32_SystemServices
            Win32_SystemSetting
            Win32_SystemSlot
            Win32_SystemSystemDriver
            Win32_SystemTimeZone
            Win32_SystemUsers
            Win32_TapeDrive
            Win32_TemperatureProbe
            Win32_Thread
            Win32_TimeZone
            Win32_Trustee
            Win32_TypeLibraryAction
            Win32_UninterruptiblePowerSupply
            Win32_USBController
            Win32_USBControllerDevice
            Win32_UserAccount
            Win32_UserDesktop
            Win32_VideoConfiguration
            Win32_VideoController
            Win32_VideoSettings
            Win32_VoltageProbe
            Win32_WMIElementSetting
            Win32_WMISetting

             */



            Console.ReadLine();
        }

    }
}
