DB
 - Scaffold-DbContext "Server=tcp:54.151.235.125,1433;Database=dev-crowdfundingplatform;User ID=dev-fseed;Password=PX:K37(Mh8T4WdktUx#yZ$+?a_D;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entity -ContextDir Context -Context UnikrowdContext -NoOnConfiguring -f
 - Scaffold-DbContext "Server=tcp:54.151.235.125,1433;Database=crowdfundingplatform-staging;User ID=dev-fseed;Password=PX:K37(Mh8T4WdktUx#yZ$+?a_D;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entity -ContextDir Context -Context UnikrowdContext -NoOnConfiguring -f
 - public UnikrowdContext()
	{
	   this.ChangeTracker.LazyLoadingEnabled = false;
	}