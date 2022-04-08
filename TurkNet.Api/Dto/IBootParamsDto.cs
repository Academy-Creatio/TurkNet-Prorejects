namespace TurkNet.Api
{
	public interface IBootParamsDto
	{
		string Message { get; set; }
		string RedirectUri { get; set; }
		BootParamsResultDto Result { get; set; }
		string ResultCode { get; set; }
		bool Status { get; set; }
	}
}