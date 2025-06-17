using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using Verse.AI;

namespace ForgottenRealms
{
    public class CompTargetEffect_IllithidTadpole : CompTargetEffect
	{
		public override void DoEffectOn(Pawn user, Thing target)
		{
			if (user.IsColonistPlayerControlled && user.CanReserveAndReach(target, PathEndMode.Touch, Danger.Deadly))
			{
				Job job = JobMaker.MakeJob(ForgottenRealmsDefOf.Forgotten_UseTadpoleOn, target, parent);
				job.count = 1;
				user.jobs.TryTakeOrderedJob(job, JobTag.Misc);
			}
		}
	}
}
