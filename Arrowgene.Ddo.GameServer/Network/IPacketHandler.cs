﻿namespace Arrowgene.Ddo.GameServer.Network
{
    public interface IPacketHandler
    {
        void Handle(Client client, Packet packet);
        ushort Id { get; }
    }
}
