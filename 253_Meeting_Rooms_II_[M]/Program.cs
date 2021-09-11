using System;

namespace _253_Meeting_Rooms_II__M_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] intervals = new int[][] {
               new int[] {0, 30}, new int[] {5, 10}, new int[] {15, 20} };

            // int[][] intervals = new int[][] { new int[] { 7, 10 }, new int[] { 2, 4 } };
            Console.Write(MinMeetingRooms(intervals));
        }

        public static int MinMeetingRooms(int[][] intervals)
        {
#if true

            //  1. Priority Queues

            //  We can't really process the given meetings in any random order.
            //  The most basic way of processing the meetings is in increasing order of their 'start times'.
            //  and this is the order we will follow.
            //  After all, it makes sense to allocate a room to the meeting that is scheduled for 9 a.m. 
            //  in the morning before you worry about the 5 p.m. meeting right?

            //  Let's do a dry run of an example problem with sample meeting times and see what our algorithm should be abel to do efficiently.

            //  We will consider the following meeting times for our example '(1, 10), (2, 7), (3, 19), (8, 12), (10, 20), (11, 30)'.
            //  The first part of the tuple (집합) is the start time for the meeting and the second value represents the ending time.
            //  We are considering the meetings in a sorted order of their start times.
            //  The first diagram depicts (그리다) the first three meetings where each of them requires a new room 
            //  because of collisions (충돌).

            //  (1, 10), (2, 7), (3, 19), (8, 12), (10, 20), (11, 30)

            //  Process Meeting: (1, 10)
            //      Since there is no meeting room allocated.(할당하다)
            //      We will allocate a new meeting room to this specific meeting.

            //  Process Meeting: (2, 7)
            //      There is one meeting room that is allocated to the first meeting which is ongoing and hasn't finished yet.
            //      So, we will allocate a meeting room to this specific meeting.

            //  Process Meeting: (3, 19)
            //      There are two meeting romms with mettings that are ongoing.
            //      One meeting is due to finish at time = 7 and the other one at time = 10
            //      So, we will allocate a meeting room to this specific meeting.

            //  The next 3 meetings start to occupy some of the exsiting rooms.
            //  However, the last one requires a new room altogether 
            //  and overall we have to use 4 different rooms to accommodate(수용하다 제공하다) all the meetings.

            //  Process Meeting: (8, 12)
            //      The meeting room #2 is free by the time this meeting is to start.
            //      The last meeting in room #2 finished at time 7.
            //      So we can allocate room #2 to this specific meeting.
            //      We did not have to allocate a new room here.
            //      Max number of rooms used till this point is still 3.

            //  Process Meeting: (10, 20)
            //      The meeting in room #1 has just finished and this meeting can start off.
            //      This does not count as a collision.
            //      So, we again reuse an existing room and did not have to allocate a new one.

            //  Process Meeting: (11, 30)
            //      No room is free here and we have to allocate a 4th room unfortunately to accommodate this meeting.
            //      Total number of rooms jumps to 4 now.

            //  Sorting part is easy, but for every meeting how do we find out efficiently if a room is available or not?
            //  At any point in time we have multiple rooms that can be occupied and we don't really care which room is free 
            //  as long as we find one when required for a new meeting.

            //  a naive way to check if a room is available or not is to iterate on all the room and see if one is available when we have a new meeting at hand

            //  However, we can do better than this by making use of Priority Queues or the Min-Heap data structure.

            //  Instead of manually iterating on every room that's been allocated and checking if the room is available or not, 
            //  we can keep all the rooms in a min heap where he key for the min heap would be the ending time of meeting.

            //  So, every time we want to check if any room is free or not, simply check the topmost element of the min heap as that would be the room
            //  that would get free earliest out of all the other rooms currently occupied.

            //  If the room we extracted from the top of the min heap isn't free, then 'no other room is'. So, we can save time here and simply allocate a new room.

            //  Let us look at the algorithm before moving onto the implementation.

            //  Algorithm

            //  1. Sort the given meetings by their 'start time'.
            //  2. Initialize a new 'min-heap' and add the first meeting's ending time to the heap.
            //      We simply need to keep track of the ending times as that tells us when a meeting room will get free. 
            //  3. For every meeting room check if the minimum element of the heap i.e the room at the top of the heap is free or not.
            //  4. If the room is free, then we extract the topmost element and add it back with the ending time of the current meeting we are processing
            //  5. if not, then we allocate a new room and add it to the heap.
            //  6. After processing all the meetings, the size of the heap will tell us the number of rooms allocated.
            //      This will be the minimum number of rooms needed to accommodate all the meetings.

            //  Let us not look at the implementation for this algorithm.

            // Check for the base case. If there is no intervals return 0;
            if (intervals.Length == 0)
                return 0;

            return 0;

#elif true
            // Greedy 문제

            // brute force
            // 내코드 실패

            // 1. 기본적으로 start time을 기준으로 정렬해준다.
            // 2. 첫번째 end time을 기준으로 나머지 start time이 작을시 방을 추가한다.

            int[] tmp = null;

            // 기본 sorting by start time
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i - 1][0] > intervals[i][0])
                {
                    tmp = intervals[i - 1];
                    intervals[i - 1] = intervals[i];
                    intervals[i] = tmp;
                }
            }

            int room_cnt = 0;
            for (int i = 0; i < intervals.Length; i++)
            {
                int selected_end_time = intervals[i][1];
                for (int j = i + 1; j < intervals.Length; j++)
                {
                    if (selected_end_time > intervals[j][0] || i == 0)
                    {
                        room_cnt++;
                    }
                }
            }

            if (intervals.Length > 0 && room_cnt == 0)
                room_cnt++;

            return room_cnt;
#endif
        }
    }
}
