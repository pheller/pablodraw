using Eto.Drawing;

namespace Pablo.Formats.Naplps;

public class NaplpsHandler : Handler
{
	public NaplpsHandler(NaplpsDocument doc) : base(doc)
	{
	}

	public override Size Size { get; }
	public override bool CanEdit { get; }
	public override void GenerateRegion(Graphics graphics, Rectangle rectSource, Rectangle rectDest)
	{
		throw new System.NotImplementedException();
	}
}