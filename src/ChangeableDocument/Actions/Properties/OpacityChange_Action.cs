﻿using ChangeableDocument.Changes;

namespace ChangeableDocument.Actions.Properties
{
    public record class OpacityChange_Action : IStartOrUpdateChangeAction
    {
        public OpacityChange_Action(Guid memberGuid, float opacity)
        {
            Opacity = opacity;
            MemberGuid = memberGuid;
        }

        public Guid MemberGuid { get; }
        public float Opacity { get; }

        UpdateableChange IStartOrUpdateChangeAction.CreateCorrespondingChange()
        {
            return new StructureMemberOpacity_UpdateableChange(MemberGuid, Opacity);
        }

        void IStartOrUpdateChangeAction.UpdateCorrespodingChange(UpdateableChange change)
        {
            ((StructureMemberOpacity_UpdateableChange)change).Update(Opacity);
        }
    }
}
