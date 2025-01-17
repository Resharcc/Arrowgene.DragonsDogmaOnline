using Arrowgene.Buffers;
using Arrowgene.Ddon.Shared.Model;
using Arrowgene.Ddon.Shared.Network;

namespace Arrowgene.Ddon.Shared.Entity.PacketStructure
{
    public class C2LLoginReq : IPacketStructure
    {
        public string OneTimeToken { get; set; }
        public PlatformType PlatformType { get; set; }

        public PacketId Id => PacketId.C2L_LOGIN_REQ;

        public class Serializer : EntitySerializer<C2LLoginReq>
        {
            public override void Write(IBuffer buffer, C2LLoginReq obj)
            {
                WriteMtString(buffer, obj.OneTimeToken);
                buffer.WriteEnumByte(obj.PlatformType);
            }

            public override C2LLoginReq Read(IBuffer buffer)
            {
                C2LLoginReq obj = new C2LLoginReq();
                obj.OneTimeToken = ReadMtString(buffer);
                if (!buffer.ReadEnumByte(out PlatformType platformType))
                {
                    platformType = PlatformType.None;
                }

                obj.PlatformType = platformType;
                return obj;
            }
        }
    }
}
