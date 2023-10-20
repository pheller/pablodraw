using System;
using System.IO;
using Eto.Forms;

namespace Pablo.Formats.Naplps;
public class FormatNaplps : Animated.AnimatedFormat
{
	public FormatNaplps(DocumentInfo info) : base(info, "naplps", "NAPLPS", "nap", "pdi")
	{
	}

	public void Load(Stream stream, NaplpsDocument document, NaplpsHandler handler)
	{
		var reader = new BinaryReader(stream);
		var commands = document.Commands;
		
		commands.Clear();

		try
		{
			while (!stream.IsEOF())
			{
				byte b = reader.ReadByte();
				var command = NaplpsCommands.Create(b, document);
				
				// Console.WriteLine("read byte");
			}
		}
		catch (EndOfStreamException)
		{

		}
	}
}	

