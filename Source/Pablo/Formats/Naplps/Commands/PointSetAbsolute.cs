namespace Pablo.Formats.Naplps.Commands;

public class PointSetAbsolute : NaplpsCommand
{
	public class Type : NaplpsCommandType<PointSetAbsolute>
	{
		public override int OpCode
		{
			get { return 045;  }
		}
	}
	
}