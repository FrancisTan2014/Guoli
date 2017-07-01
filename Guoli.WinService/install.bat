%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe obj\debug\Guoli.WinService.exe
Net Start DataSyncService
sc config DataSyncService start= auto