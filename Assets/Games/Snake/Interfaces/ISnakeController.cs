using UnityEngine;
using System.Collections;

public interface ISnakeController
{
    //Полученные напрвления будут иметь значения 2 - верх, 8 - низ, 4 - лево, 6 - право
    //Что соответствует кнопкам на телефоне в оригинале игры

    void SetDirection(int i);
    int GetDirection();
}
