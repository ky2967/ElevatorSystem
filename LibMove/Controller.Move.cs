using LibModel;
using System;
using System.Collections.Generic;
using System.Event;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMove
{
    public partial class Controller
    {
        private void ElevatorThread()
        {
            while (true)
            {
                Thread.Sleep(100);

                // 눌린 층이 없으면 Idle
                if (model.ReservedFloorList.Count == 0)
                {
                    model.MoveState = enMoveState.Idle;
                    continue;
                }

                // 눌린 층 List에서 맨 첫번째 층을 보고 올라갈지 내려갈지 결정
                if ((model.NowFloor != model.ReservedFloorList[0]))
                {
                    if (model.NowFloor > model.ReservedFloorList[0])
                        model.MoveState = enMoveState.Down;
                    else
                        model.MoveState = enMoveState.Up;

                    // MoveState를 보고 이동
                    ElevatorMove(model.MoveState);
                }
                // 눌린 맨 첫번째 층이 현재 층과 같다면 문열기
                else
                    DoorControl();
            }
        }

        private void ElevatorMove(enMoveState eMoveState)
        {
            while (true)
            {
                // MoveState에 따라 1초에 현재층을 한 층씩 이동
                Thread.Sleep(1000);
                switch (eMoveState)
                {
                    case enMoveState.Up:
                        model.NowFloor++; break;
                    case enMoveState.Down:
                        model.NowFloor--; break;
                }

                // 현재 층이 눌린 층 List에 있을 때 문열기
                // 현재 층이 1층 혹은 꼭대기층까지 갔을 때(눌린층이 해제되어 List에 현재 층과 일치하는 층이 없을 때) 문열기
                if (model.ReservedFloorList.Contains(model.NowFloor)
                    || model.NowFloor == 1 || model.NowFloor == model.AllFloorCount)
                {
                    DoorControl();
                    break;
                }
            }
        }

        /// <summary>
        /// Floor Button을 눌렀을 때 눌린 층 List에서 State 확인 후에 층 추가 or 제거
        /// </summary>
        /// <param name="bChoiceState"></param>
        /// <param name="iFloor"></param>
        public void FloorReserve(dynamic bChoiceState, dynamic iFloor)
        {
            if (bChoiceState)
                model.ReservedFloorList.Add(iFloor);
            else
                model.ReservedFloorList.Remove(iFloor);
        }
    }
}
