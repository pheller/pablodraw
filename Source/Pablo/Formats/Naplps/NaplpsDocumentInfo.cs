using Eto;

namespace Pablo.Formats.Naplps;

public class NaplpsDocumentInfo : Animated.AnimatedDocumentInfo
{
	public const string DocumentID = "naplps";
	
	public NaplpsDocumentInfo()
		: base(DocumentID, "NAPLPS Document")
	{
		Formats.Add(new FormatNaplps(this));
		ZoomInfo.FitWidth = true;
		ZoomInfo.FitHeight = true;
	}

	public override bool CanEdit
	{
		// TODO after loading is supported
		// get { return true; }
		get;
	}
	public override Format DefaultFormat
	{
		get { return Formats["naplps"]; }
	}
	public override Document Create(Platform generator)
	{
		Document doc = new NaplpsDocument(this);
		doc.Generator = generator;
		return doc;
	}
}