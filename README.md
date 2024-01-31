## 챌린지 헥사곤
![image](https://github.com/minsooBak/ChallengeHexagon/assets/56661597/78d45858-8043-4307-883c-a5f5ba2e8fa9)
# 🎮고전게임 재해석해서 만들기
#### <span style="color:blue"> 🧑‍🤝‍🧑참여인원 밑 역할 </span>
|팀원|직책|깃헙 링크|
|------|---|---|
|박민수|팀|[Minsoo]([https://github.com/BakGuno/Bak-s-study](https://github.com/minsooBak))|
|강성원|팀원|[ChocoMucho]([https://github.com/siryu2409](https://github.com/ChocoMucho))|
|최보훈|팀장|[bohun]([https://github.com/sda0503](https://github.com/iou-bohun))|
|추민규|팀원|[naddorf]([https://github.com/leejh0469](https://github.com/cn7249))|
* 박민수 - 오브젝트 메니저
* 추민규 - UI, UX, 카메라 회전, 게임 매니저
* 강성원 - 오디오 매니저, 오브젝트 풀링
* 최보훈 - 데이터 저장 및 불러오기, Player 

#### <span style="color:orange"> 📝컨밴션 규칙
</span>![image](https://github.com/minsooBak/ChallengeHexagon/assets/56661597/118c4122-0818-4dc9-a017-650c6ec63d45)

#### 🤝 팀 규칙 
1. 스크럼 오전 10시 / 오후 7시 30분
	 오전 : 작업할 내용 짧게 나누고 점검
	 오후 : 작업한 내용 나누고 보완할 점 의논

2. 말 예쁘게 하기

3. 퇴실 잊지 말기

4. 🕘 열공 중 인증하기 잊지 말기

5. 점심시간 1시~2시, 저녁시간 6시~7시

6. 물이나 화장실은 채팅만 남기고 갔다오기

7. 집중 안되거나 졸리면 10분정도 리프레쉬 하고 오기

### 기획 
![image](https://github.com/minsooBak/ChallengeHexagon/assets/56661597/de2b1740-fd13-4b41-8029-2182e00c03eb)

### 🎥 구성 씬
- Main화면
   - 플레이어 캐릭터 선택
   - 상점
   - 오디오 조절
   - 랭킹화면
   - 게임 시작
- 인게임 플레이
   - 게임 플레이
- 랭킹
   - 랭킹 확인

### 🧰 구현 기능
- 오브젝트 풀링을 이용한 충돌 벽 관리 
- 오디오 ----
- 카매라 ----
- 플레이어 InpuySystem을 이용한 조작
- Json을 이용한 데이터 저장

### 트러블 슈팅 
- [이미지를 하나씩 그리게 되어 Batches가 높아지고 SetPassCall도 많아짐](#S1)
- [플레이어가 움직임을 멈추지 않고 계속 움직인다.]
- [There are 2 audio listeners in the scene.]
- [효과음 재생하는 16개 채널 중 2번째 채널만 사용하는 문제]
- [Wall에 데이터를 깔끔하게 전달하기 힘든 문제]
- [오브젝트 풀로 Wall을 인스턴스화 시키면 작아지는 문제]
- [BPM 계산이 조금씩 계속 어긋나는 현상]

---------------------------
#### 트러블 슈팅 상세 내용
##### S1
![image](https://github.com/minsooBak/ChallengeHexagon/assets/56661597/91d2a589-f112-43df-a584-2dbd677fc7fe)

##### S2
> PlayerInput시스템을 이용해서 마우스 클릭 인풋을 받아 플레이어의 좌 우 이동을 조작하고자 하였다.
> 
> 
> 마우스를 클릭을 하면, 좌,우 클릭에 따라서 vector2가 다음과 같이 할당된다.
> 
> 좌 클릭의 경우 (-1,0) 우 클릭의 경우 (1,0)
> 
> 이 방법을 사용한 경우 좌우 이동은 잘 되지만, 클릭을 안할때 즉 플레이어가 가만히 있어야 하는 (0,0)상황의 초기화를 해주지 못하는 문제가 발생하였다.
> 
> = 플레이어가 멈추지 않고 계속 움직인다.
> 

### 해결 방법

PlayerInput의 ActionType을 value로 하게되면 입력이 들어올때와, 입력이 끊길때 두번 Input이 실행 된다는 것을 알게 되었다.

!https://velog.velcdn.com/images/iou-bohun/post/e25d2748-cf32-4f5c-a20a-b232c6f63e14/image.png

```
 public void OnRightClick(InputValue inputValue)
 {
     Debug.Log(inputValue);
     Vector2 dirVec = Vector2.right;

     if (!inputValue.isPressed)
     {
         dirVec = Vector2.zero;
     }
     CallMoveEvent(dirVec);
 }
```

또한 InputValue인자를 통해서 inputValue.isPress를 이용해 누르는 경우, 떼는 경우 두 가지 경우를 나눠서 관리할 수 있다는 것을 알게되었고, 떼는 경우에 초기화를 진행해 주었다.

### 생겨난 아이디어

이게 오류라고 생각하면 고치는게 맞지만, 달리 생각해 보았다. 플레이어가 멈추지 않고, 계속 움직이는 스타일의 게임을 만들고 싶다면, 초기화를 해줄 필요 없이 수정 전의 코드를 이용하면 좋겠다고 생각하였다.
##### S3
##### S4
##### S5
##### S6
##### S7
##### S8
