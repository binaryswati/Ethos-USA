
namespace Pal.Utility
{
	public class EnumClass
	{
		public enum HCPKeyType
		{
			Text = 1,
			Number = 2,
			Bool = 3,
			Radio = 4,
			Checkbox = 5,
			DropDown = 6
		}

		public enum HCPEntityType
		{
			IDType = 1,
			Speciality = 2,
			ResearchInt = 3,
			PharmaRelation = 4
		}

		public enum ReturnErrorMsgType
		{
			Error = 0,
			Success = 1,
			AccountNotFound = 2,
			ItemNotFound = 3,
			BigAmount = 4,
			SmallAmount = 5,
			DateNotInCurrentFy = 6,
			AlreadyExists = 7
		}

		public enum EnumListType
		{
			YesNoGrp,
			ContractStatus,
			Region,
			NovartisRegion,
			Tier,
			StateCode,
			SeniorGrp,
			DLBC_PED,
			TransplantGrp,
			BrandAffiliation,
			PharmaDiseaseState,
			TrainedOn,
			EmailTemplate,
			OnboardingStatus
		}

		public enum EnumListRegionType
		{
			Country,
			State,
			City
		}

		public enum HCPProjectStatus
		{
			Pending = 1,
			Invited = 2,
			Accepted = 3,
			Rejected = 4,
			Confirm = 5,
			InterviewDone = 6,
			Awaited = 7,
			RSVPVenue = 8,
			RSVPVirtual = 9,
			LaterAccepted=10 //added by binary
		}

		public enum EmailImageType
		{
			Header = 1,
			Footer = 2
		}
		}
	}
