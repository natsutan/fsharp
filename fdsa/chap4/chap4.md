Are We there wet
-------
##  Diving deep into enumerations and sequences

�V�[�P���X<seq 'T>��'T seq�́Ageneric type 'T ��IEnumerable<'T>�ł���B

.NET framework�N���X���C�u�����ł�, IEnumerable<'T>�́A�R���N�V�������C�e���[�g����enumrator�����炷�C���^�[�t�F�C�X���`���Ă���B
�C���^�[�t�F�C�X��h�A�^�Ƃ̊֌W��񋟂��A attributes��method�̏W�܂�ł���B
���ۂ̃C���^�[�t�F�C�X�̎����́A�������������N���X�̒��ɂ���B

seq<'T>�͕ʖ��ŁA�ق���.NET�� IEnumerable<�ƃR���p�`�u���ł���B
�V�����V�[�P���X�͊ȒP�ɒ�`�ł���B
```
let countToTen = seq { 1..10 }
```
�]���̓f�t�H���g�Œx���ł���B

```
let intExp = 
  seq { 
    for i in 0..999 do
      yield i
  }
```  

```
let intExp = 
  seq { 
      for i in 0..999 -> i
  }
```
yeild��->�Œu����������B �v�f�ł͂Ȃ��V�[�P���X��yeild�������Ƃ��́Ayeild!���g���B  

Seq.init�́A�ŏ��̃p�����[�^�[�ɃV�[�P���X�̌��A���ɃW�F�l���[�^���L�q���邱�ƂŃV�[�P���X�𐶐�����B
```
let integers = Seq.init 1000 (fun i -> i + 1)  
val integers : seq<int>
```

Seq.initInfinite �͖����V�[�P���X�𐶐�����B  

Seq.iter�̓V�[�P���X�̃C�e���[�^�𐶐�����B
```
seq { 0..9 } |> Seq.iter (printfn "%i")
```  

To fold or not to fold, this is a very functional question.   
fold�̓���́ASeq���W���[�����񋟂���ʂ̃T�[�r�X�ł��Bfold���\�b�h�́A���͂Ƃ��ăV�[�P���X�A��̈������Ƃ�֐��Asignature�ɏo�Ă��鏉���l���Ƃ�B

```
Seq.fold : ('State -> 'T -> 'State) -> 'State -> seq<'T> -> 'State 
```  
'State -> 'T -> 'State�́A�V�[�P���X���炻�ꂼ��̗v�f�̏�Ԃ��X�V����֐���\���B
����State�͏����l��\���Aseq<'T>�͓��͂̃V�[�P���X�������B

```
seq { 1 .. 100 } |> Seq.fold (fun x y -> x + y) 0;;
```

