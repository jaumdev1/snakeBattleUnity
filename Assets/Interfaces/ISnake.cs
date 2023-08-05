
using UnityEngine;

public interface ISnake
{
    void Attach(IPower observer);
    void Detach(IPower observer);
    void Notify();
}