## 챌린지 헥사곤
![image](https://github.com/minsooBak/ChallengeHexagon/assets/56661597/78d45858-8043-4307-883c-a5f5ba2e8fa9)
# 🎮고전게임 재해석해서 만들기
#### <span style="color:blue"> 🧑‍🤝‍🧑참여인원 밑 역할 </span>
|팀원|직책|깃헙 링크|
|------|---|---|
|박민수|팀|[Minsoo](https://github.com/BakGuno/Bak-s-study](https://github.com/minsooBak)|
|강성원|팀원|[ChocoMucho](https://github.com/siryu2409](https://github.com/ChocoMucho)|
|최보훈|팀장|[bohun](https://github.com/sda0503](https://github.com/iou-bohun)|
|추민규|팀원|[naddorf](https://github.com/leejh0469](https://github.com/cn7249)|
* 박민수 - 오브젝트 메니저
* 추민규 - UI, UX, 카메라 회전, 게임 매니저
* 강성원 - 오디오 매니저, 오브젝트 풀링
* 최보훈 - 데이터 저장 및 불러오기, Player 

### <span style="color:orange"> 📝컨밴션 규칙
</span>![image](https://github.com/minsooBak/ChallengeHexagon/assets/56661597/118c4122-0818-4dc9-a017-650c6ec63d45)

### 🤝 팀 규칙 
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
- 오디오 채널 구현, 오디오 믹서로 오디오 효과 구현
- 카매라 ----
- 플레이어 InpuySystem을 이용한 조작
- Json을 이용한 데이터 저장

### 트러블 슈팅 
- [이미지를 하나씩 그리게 되어 Batches가 높아지고 SetPassCall도 많아짐](#S1)
- [플레이어가 움직임을 멈추지 않고 계속 움직인다.](#S2)
- [There are 2 audio listeners in the scene.](#S3)
- [효과음 재생하는 16개 채널 중 2번째 채널만 사용하는 문제](#S4)
- [Wall에 데이터를 깔끔하게 전달하기 힘든 문제](#S5)
- [오브젝트 풀로 Wall을 인스턴스화 시키면 작아지는 문제](#S6)
- [BPM 계산이 조금씩 계속 어긋나는 현상](#S7)

---------------------------
### 트러블 슈팅 상세 내용
## S1
![image](https://github.com/minsooBak/ChallengeHexagon/assets/56661597/91d2a589-f112-43df-a584-2dbd677fc7fe)

## S2
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
## S3
### 문제

새 Camera 추가 시 다음과 같은 메시지가 지속적으로 콘솔 창에 출력.

‘There are 2 audio listeners in the scene. Please ensure there is always exactly one audio listener in the scene.’

### 원인

새 Camera 추가 시 기본적으로 AudioListener 컴포넌트가 추가 되기 때문에

기존의 ‘Main Camera’와 새로 만든 ‘UI Camera’ 둘 다 AudioListener 컴포넌트를 가지고 있기 때문이었다.

### 해결

UI Camera의 AudioListener 컴포넌트를 제거했다.
## S4
여러 효과음들이 서로를 간섭하지 않고 동시에 재생되기 위해서는 여러개의 채널(Audio Souce)을 사용하면 된다.

하지만 구현한 코드로는 현재 가리키는 채널의 인덱스가 1에서 멈추기 때문에 효과음이 재생 중일 때 다른 효과음을 재생하면 기존 효과음은 정지해버린다.

```csharp
public void SFXPlay(SFX sfx)
{
    for(int i = 0; i < sfxPlayers.Length; ++i)
    {
        int loop = (i + sfxChannelIndex) % sfxPlayers.Length;

        if (sfxPlayers[i].isPlaying)
            continue;

        sfxChannelIndex = loop;
        sfxPlayers[loop].clip = sfxClips[(int)sfx];
        sfxPlayers[loop].Play();
        break;
    }
}
```

### 해결

```csharp
    if (sfxPlayers[i].isPlaying)
            continue;
```

의 `i`를 계속 도는 인덱스인`loop`로 바꾸니 해결됐지만 이유는 파악해야함.
### S5
해결과정

데이터 전달 방식에서 고민 하다가 일단 ObjectManager → Object → Wall로 옮기는 식으로 진행

1.기초데이터를 제네릭 Type T data
    1.WallEventManager로 ScriptableObejct  오브젝트를 배열로 묶어서 저장
    2.GameManager에서 WallEventManager에 데이터를 넣어주고 EventMain에서 데이터꺼내서 처리

제네릭이 직렬화가 안되어 생성 불가

3.struct로 변경하여 WallEventManager에 일정 수 만큼 만듬

1. GameManager에서 AddData를 통해 데이터와 타입을 넣어주고 index값을 리턴
2. index값을 ObjectManager → object → wall에 전달하고 eventMain에서 index값을 통해 WallEventManager.GetData로 처리

결과 : 여전히 Wall에 데이터를 넘기는데 번거롭지만 데이터 전체를 옮기는 것에서 index값만 넘겨주는것으로 종료
### S6
오브젝트 풀로 Wall 프리팹을 인스턴스화한 후에 Object에 종속시키면 아래와 같이 된다.

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/83c75a39-3aba-4ba4-a792-7aefe4b07895/9bc6bd30-c8b3-47f9-9039-17f0b9759a9c/Untitled.png)

크기가 월드에 맞춰져서인지 엄청 작아지고 로테이션의 z도 월드의 0에 맞춰진상태가 된듯하다.

Wall.cs에서 스케일을 (1, 0.06, 1), 로테이션을 (0,0,0)으로 직접 설정해주면 되기는 함.

### 해결 (방향 변경)

오브젝트 풀 하나에서 여러 종류의 오브젝트를 관리하는 것이 아니라 한 종류의 오브젝트만 다루도록 변경했다.

그리고 오브젝트 풀이 필요한 부분에서 오브젝트 풀을 컴포넌트로 불러다 쓰는 방식으로 변경했다.

```csharp
public class ObjectPool : MonoBehaviour
{

    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private int _size;

    protected Queue<GameObject> _pool;

    private void Awake()
    {
        _pool = new Queue<GameObject>();

        for (int i = 0; i < _size; ++i)
        {
            GameObject obj = Instantiate(_prefab, transform);
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public GameObject SpawnFromPool()
    {
        GameObject obj = _pool.Dequeue();
        _pool.Enqueue(obj);

        return obj;
    }
}
```
### S7
### 문제 상황

BPM(Beats Per Minute, 분당 비트 수)에 맞춰 플레이어 hp UI가 작아졌다 커지도록 하려고 했지만

무슨 이유에서 인지 계산 식은 정확하나 계속 애니메이션과 박자가 맞질 않는 것이었다.

### 원인 추정

박자 하나가 가지는 길이는 60초 / BPM 이다. 가령 BPM이 120이라면 4분박 하나 당 0.5초의 길이를 가진다.

그래서 내가 작성했던 코드는 일종의 반복문을 만들고 박자 하나 만큼의 길이를 넘는 조건을 만족하면

시간이 0으로 초기화 되는 방식이었다.

```csharp
private void CheckBPM(int bpm)
{
    chunk = 60f / bpm;
    timer += Time.deltaTime;

    if (timer >= chunk)
    {
        MakeScaleMin();
        Invoke("MakeScaleOrigin", chunk / 3);
        timer = 0
    }
}
```

그러나 내가 생각 못했던 것은, Unity도 결국은 작은 단위의 프레임으로 Time.deltaTime을 계산하기 때문에,

정확히 박자 하나 만큼의 길이랑 일치하지 않는 경우가 많다는 것이다. 즉, 예상한 것보다 살짝 더 긴 오차가 생긴다.

위의 코드에서 알 수 있는 오류는, 조건을 만족하면 조건에 쓰이는 변수를 다시 초기화 한다는 데 있었다.

점점 작은 오차들이 쌓여 큰 오차를 만드는 식인 것이다.

### 문제 해결

이 같은 문제를 해결하기 위해, 조건에 쓰이는 변수는 건드리지 않고, 새로운 조건만 추가해 주는 방식을 구상했다.

count라는 반복 횟수를 나타내는 int형 변수를 할당해 조건에 그 만큼을 곱해주는 것이다.

```csharp
private void CheckBPM(int bpm)
{
    chunk = 60f / bpm;
    timer += Time.deltaTime;

    if (timer >= chunk * count)
    {
        MakeScaleMin();
        Invoke("MakeScaleOrigin", chunk / 3);
        count++;
    }
}
```

이렇게 되면 조건식을 검사하는데 있어서 약간의 소소한 딜레이가 있을 수는 있어도 전체적으로 보면 작은 오차가 쌓여 큰 오차를 만들 염려는 없게 된다.
