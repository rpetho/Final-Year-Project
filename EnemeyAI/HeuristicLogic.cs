using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class HeuristicLogic : Decision {


    public override float[] Decide(List<float> vectorObs, List<Texture2D> visualObs, float reward, bool done, List<float> memory)
    {


        if (brainParameters.vectorActionSpaceType == SpaceType.continuous)
        {
            List<float> act = new List<float>();

            act.Add(vectorObs[1]);

            act.Add(vectorObs[2]);

            return act.ToArray();
        }

        return new float[1] { 1f };
    }

    public override List<float> MakeMemory(List<float> vectorObs, List<Texture2D> visualObs, float reward, bool done, List<float> memory)
    {
        return new List<float>();
    }
}
