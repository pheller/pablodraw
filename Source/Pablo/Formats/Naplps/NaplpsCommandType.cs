using System;
using System.Collections.Generic;

namespace Pablo.Formats.Naplps;

public class NaplpsCommandDictionary : Dictionary<int, NaplpsCommandType>
{
	public void Add(NaplpsCommandType type)
	{
		this.Add(type.OpCode, type);
	}
}

public static class NaplpsCommands
{
	public static readonly NaplpsCommandDictionary Types = new NaplpsCommandDictionary()
	{
		new Commands.Reset.Type(),
		new Commands.Domain.Type(),
		new Commands.Text.Type(),
		new Commands.Texture.Type(),
		new Commands.PointSetAbsolute.Type(),
		new Commands.PointSetRelative.Type(),
		new Commands.PointAbsolute.Type(),
		new Commands.PointRelative.Type(),
		new Commands.LineAbsolute.Type(),
		new Commands.LineRelative.Type(),
	};

	public static NaplpsCommand Create(int id, NaplpsDocument document)
	{
		NaplpsCommandType type;
		if (Types.TryGetValue(id, out type))
		{
			Console.WriteLine(type.GetType().BaseType.GetGenericArguments()[0].Name);

			return type.Create(document);
		}

		return null;
	}
}
public abstract class NaplpsCommandType
{
	public abstract int OpCode { get; }
	public abstract Type CommandType { get; }
	public abstract NaplpsCommand Create(NaplpsDocument document);

	public abstract NaplpsCommand Create<R>(NaplpsDocument document)
		where R : NaplpsCommand, new();
}

public abstract class NaplpsCommandType<T> : NaplpsCommandType
	where T : NaplpsCommand, new()
{
	public override Type CommandType
	{
		get
		{
			return typeof(T);
		}
	}

	public override NaplpsCommand Create<R>(NaplpsDocument document)
	{
		if (!typeof(T).IsAssignableFrom((typeof(R))))
			throw new ArgumentOutOfRangeException("command type R is not derived from type T");

		var command = new R();
		command.CommandType = this;
		command.Document = document;
		return command;
	}

	public override NaplpsCommand Create(NaplpsDocument document)
	{
		return Create<T>(document);
	}
}
	