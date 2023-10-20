namespace Pablo.Formats.Naplps.Commands;

public class PointRelative : NaplpsCommand
{
	public class Type : NaplpsCommandType<PointRelative>
	{
		public override int OpCode
		{
			get { return 047; }
		}
	}
	
}