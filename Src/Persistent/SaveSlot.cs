using System;

namespace Game.Persistent;

public record SaveSlot(string Id, string Name, DateTime LastModified, int Version);