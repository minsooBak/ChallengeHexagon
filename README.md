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
- [이미지를 하나씩 그리게 되어 Batches가 높아지고 SetPassCall도 많아짐]
- [플레이어가 움직임을 멈추지 않고 계속 움직인다.]
- [There are 2 audio listeners in the scene.]
- [효과음 재생하는 16개 채널 중 2번째 채널만 사용하는 문제]
- [Wall에 데이터를 깔끔하게 전달하기 힘든 문제]
- [오브젝트 풀로 Wall을 인스턴스화 시키면 작아지는 문제]
- [BPM 계산이 조금씩 계속 어긋나는 현상]
