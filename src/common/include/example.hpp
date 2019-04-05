#pragma once
/* Example header file */

class Bar
{
  public:
    Bar::Bar() {}
};
class Foo
{
  private:
    int counter;
    Bar oBar;

  public:
    Foo::Foo(Bar l_oBar, int l_Counter)
    {
        oBar = l_oBar;
        counter = l_Counter;
    }
}