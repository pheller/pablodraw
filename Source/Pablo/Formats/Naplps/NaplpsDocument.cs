using System.Collections.Generic;
using System.IO;
using Eto.Drawing;
using Pablo.BGI;

namespace Pablo.Formats.Naplps;

public class NaplpsDocument : Animated.AnimatedDocument
{
	private List<NaplpsCommand> commands = new List<NaplpsCommand>();
	
	public IList<NaplpsCommand> Commands
	{
		get { return commands; }
	}
	
	public NaplpsDocument(DocumentInfo info) : base(info)
	{
	}

	public override bool IsModified { get; set; }
	public override Size Size { get; }
	public override Handler CreateHandler()
	{
		return new NaplpsHandler(this);
	}

	public BGICanvas BGI { get; set; }
	void SetBGI(NaplpsHandler handler)
	{
		var pane = handler?.ViewerControl as ViewerPane;
		var viewer = pane != null ? pane?.Viewer : null;

		if (BGI != null)
			BGI.Control = viewer;
		else
			BGI = new BGICanvas(viewer);
	}
	protected override void LoadStream(Stream stream, Format format, Handler handler)
	{
		SetBGI(handler as NaplpsHandler);

		var formatNaplps = (FormatNaplps)format;
		formatNaplps.Load(stream, this, handler as NaplpsHandler);
	}

	protected override void SaveStream(Stream stream, Format format, Handler handler)
	{
		throw new System.NotImplementedException();
	}

	public override void SetWaitHandler(WaitEventHandler waitHandler)
	{
		throw new System.NotImplementedException();
	}
}