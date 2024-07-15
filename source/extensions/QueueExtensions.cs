namespace Arinc424;

internal static class QueueExtensions
{
    internal static void Enqueue<T>(this Queue<T> self, Queue<T> other)
    {
        while (other.TryDequeue(out var value))
            self.Enqueue(value);
    }
}
