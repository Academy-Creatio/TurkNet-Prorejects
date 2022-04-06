using System.Text.Json.Serialization;

namespace TurkNet.Dto
{
	public class OperationGroupsDto
	{
		[JsonPropertyName("operationGroups")]
		public string OperationGroups { get; set; }
	}
}
