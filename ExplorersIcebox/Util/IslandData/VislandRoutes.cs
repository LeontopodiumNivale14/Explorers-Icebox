using Dalamud.Game.Network.Structures;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using System.Reflection.Metadata;

namespace ExplorersIcebox.Util.IslandData;

public class VislandRoutes
{
    // Routes for Visland, all Base64 Exports

    // Testing

    // Route's are in order of how they are. So Clam is Route 0... 
    public const string Base2Clam = "H4sIAAAAAAAACu1VTW/bMAz9KwHPjiDJn/JhwOa1RTa0S9sM6Vr0oM5qbMCWMlveUAT576NU9yPLZditWA6GyGeKfCIfpA2cyVZBDh9krybTd5Oike3k5sIMVk3YLQRw0plhjQFf9cpZqkTs2JgSchrAqdSDbLy5kN1K2RNpK9XNrGo9uJQPa1Nr20N+s4G56WtbGw35Bq4gn/I4IikXNAzgG+QxJ0xQxuMAriHnnBKRCR5t0TVazT5CzmiMPy9kWQ+YkBFHwPxUrdIW3QDmWPy+1kjtXja9CmCmrerkd7usbfXFZaC72Hh22EX/oEldHeTn12u/Iqe+Mr+eNmFsv1fTJ0BSR62x6qk29mU03/uI0TkfVG9f25fqx2N/zd0IX1qzLowuR2aIfK6bpjCDOzt6fmIv5ykqaQvTttJ1wwGO71LW9oWo845Nt5vUgYu6Vaf9jnu02G8GNmHWzyuprWmfk7oRQK6HpkHleC3UerV4WCMtIdyGM1Oq52jnfDJ3mG4b7MuDUUbwi1NfkcUhCXmS+BmwhKQiStLsn9Rhu+EgjrctDh6TiEYijXzBkPAwizPmtTFN0hhvkvAgjf/z3ggFETj+2NebRpyECd4d2aM2UkpJSFnyt+Lgh1flLavjdvsbGjzER+EIAAA=";
    public const string Base2Islewort = "H4sIAAAAAAAACu1WUU/bMBD+K+ieE8tObcfJwyTWAeomWAedypj2YFbTRkp8XeIMoar/fbZJgY6f0ObFd198d9+dP8XZwJVuDJTwUXfmJP1wMulq84itgwQuWuzX/tV3uwyWWXjsHHEBJU3gUtte19Gc6XZp3IV2K9NOnGkiONdPa6ys66D8uYEpdpWr0EK5gVso00wURHLGswR+QMkpoeFRCdxBmWU5UYUaZVvvojWTT1AyKkQC13pR9T4hI4EA/jWNsc4HJDD1xR8q66m5tjcJTKwzrf7t5pVbfQ0J6D42NA376H8sPatIL653cfWUuhU+7oL8Xk/nQdfdm5oxAUvgrEFndrX9WAbzNO4YnG+96dxb+8b8eR4v3g/wjcP1GO1iYOaRL1Vdj7EPrXvvGntnXvsZr7QbY9PoMIwABL5zXblXosE7x3Y/aQBnVWMuuz33bPZ+GH4Ik2660tZh85I0nACUtq9rL5wohcouZ09rT6soQsAVLszL7uB8xnufbpu8U4csSCZzFctJQViec87jCQhFmOLZURkHqgw1IkUhMyaftSEJl4qOojRGlHBOJRfHr8ZhaoMpIpSglO20IYuCiqiNVHKiWM6YPIrjMMWR+kuEKCnzIlYUOeFCDZdK6v9DCGeC50d1HII6fm3/AeMFwPP1CgAA";
    public const string Base2Sugarcane = "H4sIAAAAAAAACu1UXU/bMBT9K+g+p1YSJ07ih0msA1RQWaGdypj2YIhpLCW+XeJsQlX/O7ZJgY6f0ObF957cj3Ovj7yBa9FI4PBVdPJk9OVk3q9E+yi0hAAuWuzX9t8PvXKWLC12jlgCDwOYCt2L2psL0a6kuRCmku3EyMaDS/G8RqVNB/zXBmbYKaNQA9/AHfBRzHJig34CT0ISui8P4B54TGMS0iRPt9ZFLSffgEdhmgZwK0rV22KRy5viX9lIbWxCADPb+ElpS8u0vQxgoo1sxaNZKlN9dwXCfWyYGPbR/xiGAz1/3vvTUuoq/LdLsrGWzpOouw89fYEogLMGjdz1tisZzFMfMTg3vezMR3su/7yuFh8GeG5wPUZdDswscqXqeoy9G916t9gb+T7PuBJmjE0j3DIc4PguhTLvRJ13ju1+UQcuVCOn3Z57tvi8DLuESTerhDbYvBV1NwBc93VtReNloPRq8by2tIrCJVxjKd+inXOJD7bcNvikDEZJnDGa+n6MEcrCLPY3wBIS5ZTGR2UcpjKyhIQsyXbCKHIaDW8GIyxjccGOyjhMZcQRydI8yXLfMM1JFsWMem2MKMtIWhTRURuHoI3f2xd7Wmpx0QgAAA==";
    public const string Base2Ttinsand = "H4sIAAAAAAAACu1V227bMAz9lYDPjmDLlm35YcCWtUU2tEtbD+la9EGd1ViALWW2vKEI8u+jFPeS9hMSvYg8oMhD8sDewIVoJRTwRfRyMv00KZXuha4md1dmsHKS3EMAZ50Z1hjzU6+cJSvETo2poAgDOBd6EI03S9GtpD0Ttpbd3MrWg0vxtDZK2x6Kuw0sTK+sMhqKDdxAMaVpRmKa5XkAv6BIQhK6g94tFDSOSJykNNmia7Scf4UiChkL4EpUasCEEXEEzF/ZSm3xQQALLP6oNFKz3SADmGsrO/HbLpWtf7gE4T42dg/76DuWyMrT8/etv5FSX5t/z48wFuk8iqZ/U9MniAI4aY2Vz7VxLKP52UeMzuUge/vWvpZ/duM1DyN8bc16ZnQ1MkPku2qamRlc6+j5hb32M6uFnZm2xWXuAMd3KZR9Jeq8U9PtJ3VgqVp53u+5J+XHYeAQ5v2iFtqa9iWp2wAUemgaFI6XgtKr8mmNtDh3Dy5MJV+infPNPGC6bfBBHSwjYRRSTn1BVErIsjRP/Q5YThKW5PSojcPURhaTlCcJ20mDEU7DNGdeGjElaRTTKD1q4zC1QQnjPE/SxBdknHB3dt+NacTxjxPyKDqq4xDUcb/9Dy69qePjCAAA";
    public const string Base2Apple = "H4sIAAAAAAAACu1S227bMAz9lYDPqmEndhLrYUCXtUU2tMvaDNla9EGd2ViALXo2vaEI8u+jVPeS9RM2vYjngDo8pLiDC1MjaHhvOhwdvRsdN02Fo5tL6hlH2S0oOGupbyTjq9v6CAvhTokK0LGCc+N6U4Vwbdot8pnhEtslYx3IjXloyDruQN/sYEWdZUsO9A6+gT4aT2dRmk7HEwXfQadxFPszV3ANejyJozRO59O9QHK4/AA6ibNMwaUpbC+CSeQN0C+s0bE8ULCS4vfWiTVue1SwdIyt+cEby+VnLxAfckPvcMj+5VJcBXvhvg63WOpK+v30SHLFzr2pulc1g0Ci4KQmxqfaMpYhPA4ZA/jSY8ev4yv8+TheuhvoK6ZmQa4YnAnzyVbVgnrfuqDwYS/9LErDC6pr44fhCe93Yyy/GPXolNpDUU+ubY3n3QE8Wb8dhgxh2a1K45jqZ1H/A6BdX1WyOGEVrNuuHxqxlef+wQUV+JztwUe6E7m9erMd43kWTWZxPgsFpx7kyeNuZFk0S7Ikz/7vxr+wG7f7P0SH08SnBAAA";
    public const string Base2Coconut = "H4sIAAAAAAAACu1U227bMAz9lYDPjiH5GvlhwOa1RVq0y9oM2Vr0Qa3VWIAtZra8oQjy76OU9JL1ExK9iDygyEPyQGu4kq2CAr7IXo3Gn0YlPqIZ7OjuGgerRtk9BHDW4bCimB9m6SxVEXaKWEHBAriUZpCNN+eyWyp7Jm2tuqlVrQcX8nmF2tgeirs1zLDXVqOBYg0/oRhHWR6mGRN5AL+gSFjI3JkEcAtFFIkwEVzkG3LRqOlXKDhL0wCuZaUHSshDRwD/qFYZSw8CmFHxJ22Imu0GFcDUWNXJR7vQtv7mErB9bNc97KP/sSRWnp6/b/1NlPoa/748olii8ySb/l1Nn4AHcNKiVS+1aSw787OP2DnfB9Xb9/aN+r0dLz7s4BuLqxJNtWNGyIVumhIH1zp5fmFv/ZS1tCW2rXTDcIDju5DavhF13il2+0kdONetuuz33JP5x2HQEKb9rJbGYvua1G0ACjM0DQnHS0Gb5fx5RbSEcA+usFKv0c45xwdKtwk+qCOLQyHyNPb1siyME8ZF6leQpWEkOI+P0jhMaeRpyKM8ibKtNiahs0gXnL6MVMSMH4VxmMJIqYZgycTXy1mYx5xvpTHe/iBJmhy1cQjauN/8A84j5zvdCAAA";
    public const string Base2Cotton = "H4sIAAAAAAAACu1S207jMBD9lWqeTZSWJE38gLQbLuqugAJdlQXxYIhpLCWekkxAqOq/MzZpofAJu37xzNH4zJnxWcGZqjVI+KlaPdg7GORIhHZwe4kd6cH4DgScNNgtueSPXbhIF4wdIxYgQwGnynaq8uFMNQtNJ4pK3UxI1x6cq9clGkstyNsVTLE1ZNCCXME1yL1RMg6SNE7GAv6CjMIgdCcVcANyNEqDKMvSdM0pWj05BDkM41jApSpMx4TDwAnAZ11rS/xAwJSbPxrL0qjptICJJd2oB5obKs8dQbiL9cPDLvpFJavy8vx942+W1Jb4snnEtSznUVXtp56eYCjgqEbSm968lj784Sv65KLTLX2Or/TT+3rxvoevCJc52qJXxshvU1U5dm50zvyHfcyTl4pyrGvlluEAp3euDH0IddkxNrukDpyZWp+2O+nR7PsyeAmTdloqS1hvSd0PgLRdVbFxvBWMXcxelywry9yDMyz0ttolv/Ce6dbimzuiOArSbD/x/eIsiJNkHL1bwzlltD/874x/wRl36zfah/IIpgQAAA==";
    public const string Base2Clay = "H4sIAAAAAAAACu1S207jMBD9lWqeQzZxSEn9gMRmAZUVUGhRgdU+GDI0lhJPN3FAVdV/Z2zCpfAJS14852QuZy5rOFM1goSfqsXBzv5gqkzxI6/UagABHDfULfnnlVk4CwvmjogKkFEAp8p0qvLmTDULtMfKltiMLdaenKvVkrSxLcg/a5hQq60mA3IN1yB3xDALxV6UBnADcjcKI/dlAdyCFIkIo6EYxRuGZHD8C2Qcpex6qQrdcb44dPXpEWs0lgMCmHDtB21YmW06DGBsLDbq3s61Lc9dgmib67uGbfaTSFbl5fn31r8sqS3p6TWIfVnOg6raDzV9gjiAw5osvtbmqfTmgffowUWHrf1oT/Hfy3TprqenlpY5maJXxsxvXVU5da51RpfUWXzvJy+VzamueY8vhNM7V9q+C3XoiJrtpI6c6RpP2y14OPs6DB7CuJ2Uyliq35K6DYA0XVXx3fhL0GYxWy1Z1mjkAs6owDdvB07ojtNtgi/HIUQU7sWp2PUFUz6UJEnE0O8gG4ZxlmbJ9238D7fxd/MMzRHvR6EEAAA=";
    public const string Base2Marble = "H4sIAAAAAAAACu1U227bMAz9lYLPjiHLN9kPA7asLbIhXdpmSNdhD8qsxgJsMbPlDUWQfx+lpJe0n5DoReSRSB5RB9zAlWwVlPBJ9ups9OFsKrtloyCAyw6HNR18NytnqYqwC8QKShbAVJpBNt6cy26l7KW0teomVrUeXMjHNWpjeyh/bmCGvbYaDZQbuINyxLMs5HnOA/gBZcJC5pYI4B5KHkchi4XgW3LRqMlnKCOWpgHcyEoPlI/OqT7+Va0ylgICmFHtB22Ime0GFcDEWNXJ33ahbf3NJWCH2P7FcIi+IUmsPD2/3/udKPU1/nsKortE50E2/auaPkEUwHmLVj3Vpq7szY/+xt65HlRvX9u36s+uu7jcw7cW12M01Z4ZIV9104xxcE8n7wYHq17eM66lHWPbStcMBzi+C6ntC1HnXWB3mNSBc92qaX/gns/fN4OaMOlntTQW2+ek7gegNEPTkG68ErRZzR/XRKsoXMAVVur5tnO+4JLSbYN34shEyPIoSny9LA05Z4X7fvqCNA9jXhRFctLGcWpDsDBPsjxLd+KgIcKKKNmJg+ZGIvLsJI5jHRw8DrkQeZztxBGHaR5HsdfGSAgSR8Tj0+A4Bm382v4HCOsbV9YIAAA=";
    public const string Base2Branch = "H4sIAAAAAAAACu1S207jMBD9FTTPpsqltKkfkKALqLsCChR1F7QPhgyNpcRTkgmoqvrvjE24dPmExS+eczyXM+NZw5mpEDQcmgZ3dvd3Dmvj7gtQcFJTu5SHa7fwFubCHRPloCMFp8a1pgzmzNQL5BPDBdYTxiqQc7NaknXcgL5dw5Qay5Yc6DX8Br2bDAa9ZDhMFPwB3Y96kT+ZghvQSRr3ojTLko1Acjj5ATqO9vYUXJrctpJP3qU+PWGFjiVAwVRqP1gnyrhuUcHEMdbmnueWi3OfINrmuo5hm/1HpKgK8sJ9E26R1BT0/BYkviLnwZTNp5ohQazgqCLGt9oylc48CB4duGix4c/2FT6+TpfuOvqKaTkml3fKhPlly3JMrW9d0CW1jB/9jAvDY6oq44fhCa93bix/CPXomOrtpJ6c2QpPmy14NPs6DBnCpJkWxjFV70n9D4B2bVnK3oRNsG4xWy1F1mjkA84ox3dvD37SnaTbqC/LEY+S3iDpp2koKIuS9YdpOgh/EMd9gfEo+16O/2E5/m5eAJ5WkQOeBAAA";
    public const string Base2Copper = "H4sIAAAAAAAACu1VXU/bMBT9K+g+B8tO6yTOw6QtA1QQrECnMhAPZjGNpcQ3S5xNqOp/nx2SQuEntHnxvSf349ybI2cNV7JSkMI32aqj4y9HGda1aiCAswa72r34aVbeUrnDThFzSGkAl9J0suzNhWxWyp5JW6hmZlXVg0v5UqM2toX0YQ1zbLXVaCBdwx2kx2EUk4SJKA7gF6RTSqh/kgDuIQ1DQaY8YmLjXDRq9h1SRjkP4EbmunMFGfEE8K+qlLEuIYC5a/6sjaNmm04FMDNWNfK3XWpb/PAF6C42jAy76AeWjlVPrz/v+9NRagv8Nya5WEfnWZbtu559ARbASYVWjb3dWgbzax8xONedau17+1b9eV0vPg3wrcU6Q5MPzBxyocsyw86P7rwb7Kx6mycrpM2wqqRfhgc836XU9o2o906x2S3qwYWu1GW7454sPi/DLWHWzgtpLFbbov4LQGq6snTC6aWgzWrxUjtaQviEK8zVNto75/jkym2CT+rgCScsSkTfbxKTkLM44a/amIQkYpRGB23sqTaEIEIk8agNHoch5dt7g8WUhQdt7Kc2IkpJ5C6LURtTQWk8/lM4EeFkyg/a2AdtPG7+A9QTjgzWCAAA";
    public const string Base2Opal = "H4sIAAAAAAAACu1S207jQAz9FeTnECWhTdN5WAm6gLoroEBXZUE8DBvTjJSMQ+KAqqr/jmcIly6fAPMyPkee42OP13CqKwQFB7rFnd0fO2e1LiGA44a6Wug/dukizIU7IspBRQGcaNtJlgvnulkiH2susJkyVp5c6FVNxnIL6mYNM2oNG7Kg1nAFajdJR2GWZukwgL+gBlEYuTMI4BpUkmThME5HG0FkcfoTVBwNJfNC56YTvTh09ekRK7Qs+QHMpPa9seKMmw4DmFrGRv/jheHizAlE21zfL2yz/5kUU96dv6/9LZbagp5eH0mu2LnXZfuhpheIAzisiPG1tkylD/d9Rg/OO2z5Y3yJDy/TpbuevmSqJ2Tz3pkwv01ZTqhzrQu6oI7xvZ9JoXlCVaXdMBzh/C604XejDh1Rsy3qyLmp8KTdgofzz8OQIUzbWaEtU/Um6n4AlO3KUvbGb4Kxy/mqFlvjsXtwSjm+ZTvwi+5EbhN8Wo4kzsK9ZJD6eqMkjMejLB76L9hLw1Ti79X4Eqtxu3kGEtYMApoEAAA=";
    public const string Base2Hemp = "H4sIAAAAAAAACu1S227bMAz9lYLPrmE5thPrYcCW9ZIN7bI2Q7YWe1BrNhZgiZ4tryiC/Psozb1k/YRVL+I5oA4PKW7hXBkECR9UjweH7w5O0bQQwUlHQ8v0N7vxEVbMHRNVIJMIzpQdVBPCleo26E6Uq7FbODSBXKuHlrR1PcjrLSyp106TBbmF7yAP02Ial6KcTSL4ATJL4sSfLIIrkGk6jfNJIdIdQ7K4+AhSJHkewYWq9MCCIvYG6DcatI4fRLDk4nfasjXXDRjBwjrs1K1ba1d/8QLJPjc2DPvsPy7ZVbAX7qtws6W+pvvHR5zLdu5U07+oGQREBEeGHD7W5rGM4fuQMYKvA/buZXyJv/6Ol25G+tJROydbjc6Y+aybZk6Db53RBQ0On/uZ18rNyRjlh+EJ73ettHs26tExdfuinlxpg2f9HjxavR4GD2HRL2tlHZknUf8DIO3QNLw4YRW03aweWrZVlv7BOVX4lO3BJ7phuV30ajvyWRaLspiFemISZ2UuiiJ8gRBZXKbTiXjbjf9hN37u/gA5LjzAnAQAAA==";
    public const string Base2MultiColor = "H4sIAAAAAAAACu1UTW/bMAz9KwXPimHZjmL7UKDN2iIb0mVtimwddlBrNRZgi5ktbSiC/PdRqvuRrYedt/oi8pkfj9SDtnAuWwUlHMteHYwOD+ausfoWG+xUBQzOOnQb+n1l1t4K2CliBWXMYC6Nk00wl7JbK3smba26mVVtAFfyfoPa2B7Kr1tYYK+tRgPlFj5DOUpEHk2yQqQMvkCZxVHsv5zBNZRJIqIiF3m6IxeNmr2DksfjMYMLWWlHBXnkCeAP1SpjKYHBgprfaUPUbOcUg5mxqpO3dqVt/dEXiPexYXDYR39jSawCvXBeh5Mo9TX+fEyiWKJzJ5v+Rc9QgDM4adGqx960lsE8ChGD88mp3r60L9X3h/XizQBfWtxM0VQDM0I+6KaZovOjk3eBzqrneaa1tFNsW+mX4QHPdyW1fSbqvVPs9ot6cKlbNe/33JPln8ugJcz6RS2NxfapqL8BKI1rGhJOkII26+X9hmgVhU84x0o9RXvnPd5QuR17RR1ZHpE4kiJ0FDziSTzO00EdMamj4NnfqoNu4k0d/5A6kjiOJnmW8NCQFyQHISZBG6NUpJGYpFy8ieN/eDq+7X4BVQUvuMMGAAA=";
    public const string Base2Iron = "H4sIAAAAAAAACu1S207cQAz9FeTn2Si3vWQeKrVbQKGCLrDVUlAfBmI2IyXjbeK0Qqv993pCuCx8QsnL+BzZx8eOt3BmagQNX0yLB6NPB3lDDhQcN9RthP7h1j7CQrgjogJ0qODUuM5Ufbg0zRr52HCJTc5Y9+TKPGzIOm5B32xhQa1lK6p6C1egR/FkFkySaKrgJ+g0DEL/pQquQcdJFCTxNNsJIof5V9BROB4ruDCF7UQuCnx7+oM1OpZ8BQtpfW+dGOOmQwW5Y2zMHa8sl9+9QLjPDePCPvvGo5jq3fXvdf+Kpbakv09Fkit27k3VvurZC0QKDmtifOotSxnCz33GAM47bPl1fIm/H5dLtwN9ybSZkysGZ8J8s1U1p86PLuiCOsaXeeal4TnVtfHL8IT3uzKWX4x6dETNvqgnl7bG03YPHi7fL0OWkLeL0jim+lnU/wHQrqsqOZv+EKxbLx82YivLfMEZFfic7cEJ3YrcTr27jXGaBlnsq6RfFKdBlE3S5PE2RnE8DWZJNJt9XMf/cB2/dv8ANZA/i5wEAAA=";
    public const string Base2Laver = "H4sIAAAAAAAACu2VTW/UMBCG/0o152wUJ3Gc5IAES1st0LK0Wy0UcXCJu7GUeJbEKapW+98Zu+nHFg6IE4LNxZ5X9szr8aN4A6eyVVDCK9mrg8mLg3fyRnUQwHGHw5r0C7NyM1WRdoRYQRkFcCLNIBs/XchupeyxtLXqZla1XlzK2zVqY3soP29gjr22Gg2UG/gI5STO8jDiSZ4F8AnKNAoj96UBXEIZJyyMuUjSLYVo1Ow1lCziPIAzWemBErLQGcAb1SpjaUMAcyp+rQ1Zs92gApgZqzr51S61rd+7BNGuNp4YdtVnLsmVt+fHSz+Spb7G7/ebaC3ZuZZN/6SmT8ACOGzRqvva1JZx+tKvGIMPg+rt0/m5+nbXXrwa5XOL6ymaanRGylvdNFMc3NEpOsPBqsfzTGtpp9i20jXDCc7vUmr7aNRFR9jtJnXiQrfqpN8JDxc/N4OaMOvntTQW24ek7gagNEPTEDgeBW1Wi9s12SoKt+EUK/Ww2gVv8IrSbYNf0OEIYIzHvqIgVJIiK7KRjjgUicjZ79JBN7Gn4x+iQ0RJyAvBfD1Co+BRzDwaBI0QWcrFHo3/88choiLkxIavN0lZmDPOE8/GhBVhloo8zf7oVXn2i98/K389HV+2PwB1Gume2AgAAA==";
    public const string Base2RockSalt = "H4sIAAAAAAAACu1Sy27bMBD8FWPPtKCHrcg8FGjdJFCLpK7twk2KHpiIsYhKXFdctQgM/3uXrPJw8gmtLtwZkbOzjz1cqlaDhHfK6dH4zWiJtz9GK9UQCDjvsN/xvy926yNdMXeGWIGMBVwo26smhGvVbTWdK6p1V5JuA7lR9zs0lhzIb3tYoDNk0ILcw1eQ4zQvoizJZgKuQE7iKPZfIeAaZJolUVak05MDQ7S6fA8yiadTAUtVmZ71ksjnx1+61Zb4gYAF574zlp1R12sBpSXdqVvaGKo/eYH4mBuKhmP2hUl2FeyF8zqcbMnV+PvhEd9lO3eqcc9yBoFEwGmLpB9yc1eG8G24MYDPvXb0PF7pn3+7izcDvSLczdFWgzNmPpqmmWPvS2e0xJ70Uz3zWtEc21b5ZnjC+90oQ09GPTrD7ljUk2vT6gt3BE/Xr5vBTSjdolaWsH0U9RMAafum4b0Jm2Dsdn2/Y1sznnLpLrHSj7c9+IA3LHcQr5Yjn8W8G2kx5DtJc55+HkYwTvI4SieTrPi/HP/Ccnw//AG1wAumoQQAAA==";
    public const string Base2Leucogranite = "H4sIAAAAAAAACu1UbU/bMBD+K+g+p5Eb3AT7w6StA9RtsA46dYD2wZCjsZT4usQZQlX/+84mvHT8BPAX3/PEd/f4/CgbODUNgoZPpsO90Ye9b9jf0Ko1znqEBI5b6tf8+adbhQhL5o6IStAigRPjelPHcGHaFfpj4ytsZx6bSC7N/Zqs8x3oqw3MqbPekgO9gV+gR1lepFJO1EECF6ClSEVYjC5BZ/silSIvsi1Dcjj7DHosJpMEzkxpey44ToMA+osNOs8JCcy5+a11LM23PSYwcx5bc+OX1lffQwGxyw0Xh132P5WsKsqL+2XcWVJX0d1jEp9lObem7l70jAXGCRw25PGxN49lCD/GEwP40WPnX8bn+OdhvHQ90Oee1lNy5aCMma+2rqfUh6szOqPe4/N9ppXxU2oaE4YRiKB3aax/FhrQEbW7RQO5sA2edDvwcPF6GDyEWTevjPPUPBUNLwDa9XXNxolWsG61uF+zLKVCwimV+HQ6gC90zeW2ySt35DIdZweZkLFhnrMbhCriE+T7qVCZFMW7N96oN5RIM5mrycOPI1VhZTKaY5RLmUpVyHdzvAVz/N7+A5aJLQHBBgAA";
    public const string Base2Quartz = "H4sIAAAAAAAACu1S207jMBD9FTTPaZRrm+RhpaVclF3BFuiqXMSDIaaxlHi68RgEVf99xyFcCp8AT55zPD5zZjxrOBathAJ2hZE7ox87J1Z09AQeHHZoV3zxVy9dJCvmDhArKAIPjoS2ounDueiWkg4F1bIrSbY9uRCPK1SaDBRXa5ihUaRQQ7GGcyhGURj6UZqluQcXUEwSP06icerBJRRhHvlxFoyjDUPUstxjLkj58lRUyrJe6Lv6eC9bqYmhBzOufac0O6POSg9KTbITt7RQVP9xAsE2N3QM2+wHk4Erw+7687I/2ZKp8eHlEeeynTvRmHc1ewH2tN8iyZfaPJUh/NlnDODESkPv4zP573m6eDPQZ4SrKepqcMbMb9U0U7SudUanaEm+9TOtBU2xbYUbhiOc34VQ9GbUoQPstkUdOVetPDJbcH/+eRg8hNLMaqEJ21dR9wNQaNs0vDf9Jii9nD+u2FbOn1yaY6zka7YDv/CG5Tbep+WI09AfT6LJuC8Y57mfZFn0vByjJAj8PA6S7Hs7vsJ2XG/+A3vgOrKfBAAA";
    public const string Base2Glimshroom = "H4sIAAAAAAAACu2VUW+bMBDHv0p1z8TCYIfAw6Qua6Nsape2mbJ12oM73GAJfBmYTVWU776zR9pm/QgJL/b9se/+Pv8EW7hWjYYC3qtOn43enc1q03RVi9hABLMW+w29/GLXfqZL0i4RSyjiCK6U7VUdpkvVrrWbKVfpdu50E8SVetqgsa6D4vsWFtgZZ9BCsYWvUIySsWSZFFkawTcoRMxi/0wiuIciSTnLhEzzHYVo9fwDFDyWMoJbVZqeEnLmDeBv3WjraEMECyr+aCxZc22vI5hbp1v1062Mqz77BPGhNhwbDtX/XJKrYC+M92EkS12Ff/abaC3ZeVR196pmSMAjuGjQ6X1tasswPQ8rhuCm1517Pb/Tv/61Fx8G+c7hZoq2HJyR8snU9RR7f3SKbrF3+uU800q5KTaN8s3wgve7Usa9GPXRJbaHSb24NI2+6g7Ci+XbZlAT5t2iUtYRJvuk/gagsH1dEzgBBWPXy6cN2cpzv+EaS/282gcf8YHS7aI3dEwmTMo04aHemLNcEg3hBkTOkoxPkhMZx0mGSAUbC8IhFORceFAmuQhwjLjkTGQy4yc8jhSPRLKYc56Fgnk2fLdH/o+SZiI9gXEUYPzY/QUyPGVk2AgAAA==";
    public const string Base2Water = "H4sIAAAAAAAACu2U3W7bMAyFX6XgtSNYthTZvhiwZW2RDe3SNkO2DrtQZzU2YIuZLW8ogrz7KNX9yfoIiW8kHkjkIfXBW7jUrYECPujenEzenay0Mx1EcN7hsCH9q137nSlJO0MsoYgjuNB20E3YLnW3Nu5cu8p0c2faIK70wwZr63oofmxhgX3tarRQbOEbFJNkKpmSQqURfIdCxCz2XxbBLRRJypkSMs13FKI1849Q8FjKCK51WQ+UkDNvAP+Y1lhHFyJYUPH72pI11w0mgrmlFvQvt6pd9cUniPe1sWPYV/9zSa6CvbDehpUs9RX+fbpEZ8nOvW76VzVDAh7BaYvOPNWmsYzb9+HEGFwNpnev9zfm9+N48W6UbxxuZmjL0Rkpn+ummeHgW6foGgdnXvqZVdrNsG21H4YXvN+Vrt2LUR+dYbef1IvLujUX/V54unw7DBrCvF9U2jpsn5P6F4DCDk1D4AQUartePmzIVp77C5dYmufTPviEd5RuF72hI8uYlGnCQ70pZ7kkGsILiJwlimfJkYzDJEOkgk0F4RAKci48KFkuAhwTLjkTSip+xOMw8Ujoz5EomYR6SjL5yEUiiRqVc3Xk4hC4+Ln7B1hzRC/SCAAA";
    public const string Base2Crystal = "H4sIAAAAAAAACu1V227bMAz9lYLPjmDZkm8PAzavLbKhXdZmyNZhD+qsxgZsMbPlDUGQfx+luZesn5D4ReQxRR5SB9IOrlWnoYB3atBnszdnZb8drGohgMsexw39+WLWztIVYReIFRRhAFfKjBTlzKXq19peKlvrfm5158GV2m6wMXaA4vsOFjg0tkEDxQ6+QjGLEslSKdI4gG9QiJCF7ssCuIMiijlLhYzzPblo9Pw9FDyUMoAbVTUjJeTMEcDfutPG0oYAFlT8oTFEzfajDmBurO7VT7tqbP3JJQgPsalnOET/Y0msPD2/3vmVKA01/nncRLFE50G1w4uaPgEP4LxDqx9r01gm862PmJzPox7sS/tW//o3Xryf4FuLmxJNNTEj5GPTtiWOrnXybnC0+rmfsla2xK5TbhgOcHxXqrHPRJ13gf1hUgcum05fDQfu+fL1MGgI82FRK2Oxe0rqTgAKM7YtCcdLoTHr5XZDtPLcbbjGSj9FO+cD3lO6ffBKHVnGpIwj7uslnOWS1OBPQOQsSnkWnZRxnMoQsWCJIDn4gpwLJ5QsF14cMy45E6lM+UkexymPKBGMh1mY+IIyYnlGD80kDro74jw53R3H8ar82P8F4edHFtkIAAA=";

    // Routes themselves for gathering
    public const string ClamVisland = "H4sIAAAAAAAACu2aTU/cMBCG/wryeXH9/bG3agvVtmpLAYmWqgfDGjZSEtONtxVC/PeOgxNKKRLqAbWLL5vYSZyx82hm3vFeofeu8WiKKN6a1a55Me9qf1Z1SzRBr1dhfQGXoMu1i60D157GtVtdwqXdEBZoSibonWvXru5PD93q3MfXLi79ah5903ceucuLULWxQ9MvV2gvdFWsQoumV+gTmkqOieFUTtBnNN0WAivD6AQdQ0MTi42y4hqaofXzV/1o+25RrWEohtOrw3ff+Db2V/bgtWdVC0adubrzEzRvo1+503hUxeWH9DgjlFkj717Jk++8++H9Yiu69rz26O49vxlN0rvB3v543B/ByG4ZfgwPwb3dPTv6AWByO02Iw3TSKuXTl/0dufFx7bv46/mB/3az2uEkdx/EcDEL7SJbBj1vq7qehXVej/2wjj7PDuYzW7o4C00D3/GmI9l75Kp4a2hq7YbV3UFT52HV+HfdnebO4f3FgEWYd3tL18bQjIOmz4Km7bquAaeejKo9P7y8ALOsTQ+8Dws/3p0ab8IJDHc9uQeLIJhySk2GRWImOFUDLRJLwtnT0FIn0Le6pa/rgso/iYrCWnKrMirw/QUV5gYVZSS2lqhHocIKKpvuVRTmgqSnelQo1kQwllHRBlsA6c+o0BKDnl0MohZbY9VAC09BR/FMixJYWEGLYynpCqDCGFZc00yKxoJKo3O2QjXmij4uWykhaNOdyjbDTFNjxSiDqLZCDukKxBlLH6eDCisbzwpl2FBN+cgK6BQypLYWmobrooJKBOr9isCcKzuUV8BZaKWyYlbWYq3tE2Urpb7yH7gWSbAUig9xKNHDGDfZuYAuwpbzB8QQ/wtgyB9RKRWVfxIOCp9fckNMLqqwVHAznA8pLdEY0toHqiqFjo3PSjS28JMjjQI2ZFLJPRrgSBQTJYMtWckNK5xiKVPVJCtjbuW468MIFlDML7s+ZddndC0EXIthepDHHBuINPJ2m5Aa/YDkKXFn0+MOh1ADJfox7lgu1biDbLCGqlupnBQ1nFjRGlMptbyVN9QKo0Z5wyHyqCJvnuV/C7Yp5CRGWj64EpA3VDBFsi9RloMYLlHmGcDx9fonYCHKoxMlAAA=";
    public const string IslewortVisland = "H4sIAAAAAAAACu2ZUU/bMBCA/0rl587Yju3EfZs6QN0E69ZKbEx7MNTQSEmcJc4QQvz3XRwHKONh2wNDyOpDfI5jny9fz3eXG3SsS4NmiOHJoi3MlW3c3tLW1tm9pW7aKq8nK2M2LZqiw8Z2NQyFcbraTFa6Onedbq7h1oG1GzQjU3Skq04XvrnWzaVxh9ptTbNwpvSdJ/q6tnnlWjT7doOWts1dbis0u0Ff0OwNTRUWGVFT9BXNRIqZYIpO0Snc4lRgSVVyC6KtzOKdn+6z3uQdzMVwv7b9aUpTORCnaAnrXuQVaOWazkzRonKm0efuJHfbj/3TjFCmMrF7JxhDX+qfZlLDNh3aHfBIY9KvC7r666m/goLt1l6ND8FY0O9CF+0DJfwEsLH90rpxK72JQvOtHxGET51p3cP2yvwYTG3PQvfK2Xpuq03QDHo+5EUxt11vi95KtnMmbA32M99qN7dlCS9x6Oj1PdG5u1e0lw5ssztp37nOS3PU7oj769+NAUZYtMst2M+Wd5P2rwTNqq4ogCWPRV5drq9rUEvBK1+0x3Zj7kb3wnt7BtPdTp8gRSU4S5JASoI5UyoNpHCGuVT0WUi5yovNpB7+KBGVF4kKYxnmmUoGVGBFwlIRUEk4VopFUqJT8aSAI0lJlnpSODgYyWgWSGESUx59SiQlkCIxSekASgo+RJARFKGwzJI0+pToUzwpXGJBVDagojDjVI4hbUog2pWRlEiKJyVJccIy5knxbcFCnCIonD6Z/Aen8ijxiDHt60h/AA1MKOUDKxzciCIysAJ5s0yf06v4akFMfl4mKJLjhKZD8pNQzIkQLICi+jyZqUhKrKj4QIXgDIKTgRRIhDLaRy2elIyC+KzZT/QpL/jw4UNldiSFCKjEjT4FSnFU/lmVFoRIyusvqKhQUEkIThQPoEiaYipEFl1KPHxC7iOlGOJZqNemD0hJ+lILF5GUSEoghcn+vOldCsOKKq4CKYRDcT+NPiWSMnxMFphSKsX4NVkJCr/xczKFshzbgYVCbnQfrNC/D2vJkwFtzIz/f2zy/fYXZiVz/ukgAAA=";
    public const string SugarcaneVisland = "H4sIAAAAAAAACu2Z30/bMBDH/5XJz8Hzb8d5mzpA3QRjazU2pj0YamikJu4SZxNC/O87p0mhg0nsDTE/NXaS88X+9M7f8w06tpVDBeL41ay7ss2Frd3rz2XtUIYOG9+t4d60Xdl68Wpm64vQ2eYabh14v0AFydCRrTu76i/ntrly4dCGpWumwVV956m9XvuyDi0qvt2gE9+WofQ1Km7QF1QwjhnJFTEZ+ooKabCiTAiWoTNU7HElcM5zxm+h7Ws3fdsb/GQXZQfWOI6j+5+ucnUAUxk6gZEvyxr8urSr1mVoWgfX2ItwWoblh+H1+33Dp6Pd3j98JHEc8K7/Pet/waF26X+NL8Gz7YMxewM0Q/uVD6PrcVKGyzf9E0PjY+facP965n5sJtefD92z4NcTXy8Gz6DnfblaTXwXvz3Oiu+Cu/ueydKGia8qWLZNR/T31JbhztHYOvDNrtHYOS8rd9TuNPfnDycDJmHanixtHXy1NRqXABV1t1oBPT0IZX01v16DWwYWedoe+4XbPh0b7/w5mLvNHrIhMM+VHMnIqSJ8BENiSoR6nAu2ywW5z0VousewYIQyk8tH4WjHP0Wi5FlSInHOiKL9eIriuI56wASoMcIkTFIwKTSmkmrNNpgQTDUXcsBESEwE4U+KJjtZJkWTl5ZzaMw5YyjJqST5wAg3mPNcpIyT9iUMS2OYlGMoMZrmasQEmpKyhEnCREftogdlo0DnCBNDS48JzbEUwiRMEiYgcVVOKB8xoZLnW0wgG3GpEyYJkz3KsKaC6Y3QkRyUDWNm3MJSiZk0Ut5DhZKYolKx5P8oloDYxUJpMwgcAflFky0dCoKMeNquJAmcl80JgxrroHCggEq2jDCKOSFJ4KRc08cSSQTXIyYSdiJjTZ5TEDzqacWSVHp92bEE1C7kFj7UXkH6cr7FxMDBDklCOIWTgkHBROUmH3auAIaOh3p3RzlKSqX/unOl/74/Sad8zzWIfL/9DVyL0nNwHgAA";
    public const string TinsandVisland = "H4sIAAAAAAAACu2ZXU/bMBSG/0rl62D5O3bupg5QN8EYVGJj2oWhhkRL4i5xhhDiv89JnX4MNHExIba5N4lPk+MT9+l7znHuwbGuDMgAg5N5Ube6XoAEHDa2W3rjrC29YXKm6yvX6ebOf3Vg7QJkKAFHuu50OZzOdXNj3KF2uWlmzlSD8VzfLW1RuxZkX+7BiW0LV9gaZPfgE8gIlJxJKkgCPoOMK6j6jx9dgGwPKwkRUpQ8+LGtzewtyDDiPAGnelF03iGGfQD2h6lM7YbZTvzk14UPPrvWZWsSMKudafSVOy9c/qH3gHZt4bHBrvWXMFE/jw9wOF4MRx9Tm9vb8SZ/bftozsEBTsB+ZZ0Z5/brEk7fDFeEwcfOtG77/Mx8X62vvQzmM2eXU1svQmTe8r4oy6ntwrOf2s6ZzfNMc+2mtqr6n3Iw9PGe68JtAu1HB7bZddob50Vljtqd4f788WL4RZi1J7muna3WTvufAGR1V5YeoIGFor6Z3y19WEr1NxzbhVlf3Q/e2Uvv7iF5hAeFlGNC+DCf8BMKIvkIh4JSpXKLDbQBg/wGDNd0T3FBECaq9/4EHW13WRnP9mIS/hiRlVfHioAMM67YWkk4Y+nICoKURlSirKxQ2cOQKso4WesKl+moK0JATjGLuhJz0ACLhDhFbKtAwXyUFU6gQmS7PIkp6H8uVzgkklFKR1mhSkkRWCEcIpziZ7HiYYvlyj/OioQqFb7XWbHiExJFRAZWMIMSo6grMQWtWMEIYpmGJllQ3xSnamQFMcgxoy+TgyprXT65zQtnJo29+hY7odcoLVhBISiXK1wY9AWLCiXL0AgRJiIucZNlvcmCYSrTcZOFeqkRWAVcMMRU8NgMxUwU9msR5L5ZDhWuTz2USbZiRfoCV3IRpSVKy2Z7n0NGvJyM0iI5CbSkKUQMqxdSlli3/A0t0Z99GfScJjq+C3qtDfPXh5/y1rbIkhwAAA==";
    public const string AppleVisland = "H4sIAAAAAAAACu2ZXU/bMBSG/0rl68jYjj/i3LEOUDfBGKCxMe3CUNNGSuIucZgQ4r/vOEkpHSAhJqGy5Sq2k9gnzpPz8eYGHZjCohQJPNpeLHK79c7aeXZlt75kpUUR2qtcs4Dzkzo35XR0bMoL35jqGk7tOjdFKYnQvikbk7fNE1PNrN8zfm6ribdFO3hqrhcuK32N0u836NDVmc9cidIb9BWlLJE4lkwkEfqGUikwjyVhETpDqZBYUM2ouIWuK+3kPUopESJCR2aaNTBdjMPy7soWtvQwV4QOYenLrATDLk1e2whNSm8rc+FPMz//FGYg62P986P10T+MJGEdMK89nrVHsKmeu1/Lm+Da+sGa7QQ0QjuF83a5NuxK39xur+g7nxtb+/vtY/uz21133g8fe7cYu3LaWwYjH7M8H7smPDv0jlzj7ep5xnPjx64o4L11A8HeU5P5laGht+uq9UnD4ElW2P16rbtz8nAzYBMm9eHclN4Vd5OGV4DSsslzwKclIStnJ9cLMEvrcMOBm9q7q0PngzuH6W6jR+BIMJFMLdlgiidJx4bGKhY6vocGWXHB1rkg97nwVfMYFoxQphPxKBxZB78JH8jIVzZ8GAMtm0dLrDFjtF1OKEy4kqqFBVxMQhPBnwUL+0tYCvgepyN3OZpmlR9A2US3QhOKlSKCdahIrCTtSFEcaxFr/qKI8wQsQ8B5OwGHAgAx57oLODEGp8FpF3AUJCOSvY4PGQLO26AFAo5OelgY1lwtM1eOGeXyfuI6wPKf57KUSkyI7GmBNpQ5oqUlhqInkZoOtAyVz5IWyFA0i2WXzMoEK/AznW+hCaYQOQbfMtCy8i2S4gSEkpYWBc6MayZbWliCpeJEvk7pY+ZuZsrroUbe3CgEKoqO+yJZQpHcexUOQguIK68Tg0BBzF05GzDZWEzg7WHFeO9QJNaKBO8CoEiQWDjocINDGSTalhTGMG9V2UAKAzoE77JajWVM6PMU2iHy/PP1D+Mc8pJQ8oTIA/mKILSXVgQWQrAXZLRP/eMZgs+bJgX0ego1Dr/7JSiTIMl1qCjKiXpSn6WDPvvvOJEft78B7Ezoo6AeAAA=";
    public const string CoconutVisland = "H4sIAAAAAAAACu2ZW2/TMBTHv0rl5874fskbKttUYGNslQZDPHirt0Y0cUkc0DTtu3Ny24WBNF7QYH6K7Tr2ifPr/1xyhfZd4VGGFJ7Mwlkom/jiwK2LydtwMTS8O0dTtFuFZgPz5vXalcvJkSvPYuOqS/hpJ4QlysgU7bmyceuuuXDVhY+7Lq58NY++6AaP3eUm5GWsUfbpCh2EOo95KFF2hT6gTFLMuCV0ij6iTFMsGNdCTNEJyrY0wURLSdU19EPp569QRomUU3TolnkD61Hc7h+++cKXEWVsig5g7/O8BMti1fgpmpfRV+4sHudx9a5dgNwfG84B3R/9yUiwo7Ovu550VzCpXoXv400wF8w5d+v6zp7dAvBk20WIftwbTmVovuxmDJ33ja/j3faR/9qfbjgdho9i2MxCuRwsg5E3+Xo9C0376NA7DE30t88zW7k4C0UB760faO09dnm8NbTt7YTq/qLt4CIv/F59r7u9eHgYcAjz+mDlyhiKm0XbN4CyslmvAZ+OhLy8WFxuwCxr2xv2w9LfzG47r8MpLHc9fQCHMFhJa/UIB5day4ENhhUTxNxBg9xywf6cC0Yos0b+ko5N+4+IlfcJk6eIiZSYSiN6DVEWEyOk7THhGgurDEuYJDXZYhoTojXr5URgrrjqMWEGg6ORNmGSMNliBBurrOwxkZgzaQZOlMBMaqMTJ4kTCZJBwLmMXkcSSQdKLOZUMpooSZRsUQZhK6F2jGGVBnHpObEWG0lFCk4SJ8BJG6hSbno5UVhyYQY9oQSiWMZE0pOkJ5RgarTqY1jF24DWmhETgUFO+F/BpC5CiKvJ91Ue/aQKZ19SavwUU2NqsVJcDqoiIE/WbTml8z4Ec87E3eJawuWZF9yYBEdj1FBJ4RCesLEWC7mzoPZxPgg6SVyeAS0afJG0ba2tx0Uo2qbNHS8SkmhCqHxs7f4xzKTa/T8EB8GKGst7NkBXCFVD3qM5tvRxWU9SkmfhdyTBVhJNzZglM2H4+KkHyimQJFP+WyWBKDh9Bfxf4Ph8/QP+VcNinR4AAA==";
    public const string CottonVisland = "H4sIAAAAAAAACu2ZXU/bMBSG/0rl68iyHX8ld1MHqJtgbFRiY9qFoYZGSuIucZgQ4r/vOElL+ZLGDUKdr5pz4tgnztPj99i36MhUFuVI4cnUee9qlKCDxnUr8M3a0tSLyYmpL3xnmhu4te/cAuUkQYem7kzZX85Nc2X9gfFL28y8rXrnqblZuaL2Lcp/3qJj1xa+gM7zW/Qd5VxIrKigOkE/UC4yLAQhMkFnKGdphrOMp/QOTFfb2ce+u29mUXTQF8VhbHdtK1t7aJ2gYxj3sqghKt90NkGz2tvGXPjTwi+/jE9v+8b3RQ+9jwIkYRgIrf89638hnnbp/qwfgrYQzqUp260x+w5ogvYq59eRhxkZLz/0LUbja2dbv319Yn8PM+vOR/eJd6upqxdjZOD5XJTl1HXh1cOkuM7b+/eZLo2fuqqCbzY4QrynpvD3gQZr3zUPOw3OeVHZw/aBuTd/OhkwCbP2eGlq76pNp+ELoLzuyhLQ6Sko6qv5zQrCyrLwwJFb2E3rYHxy59DdXfIUDJliSQjfcMHTgQrOMNxTz0PBXg8FI5RlWjyLxkX/P5isAH4fMXmXmCiGIVHQARMNCUMLvgEl4zz7J1DAiKDsdj5RMEjPxpBPVMo3oCgsFX1hmYmg/G8LjxI4Uzpbg0KoZBtOQKnEhBIFysBJkKdMrlcezXhQsQEUQTAjKiaUCEoPiuZYKaoGUBQWLONjhcOh+OE0jStPLHl6UBRWRIg1KERkdJQogmKpZeQkcgKcCMkwVWyQskxiItU6oSiOJVPsTYpjc2WubayN36+SFanGbNhOC6AIkLKciVHMBvWSCvJCTombaztd4wgStGua9uNRkCRSazpwkaVgZdnrM8ijDdCYQnYBFK4hE0g5SBLGwi4sGRJISgXmafomK83KlNXEN9bGPdj3CEkqNSZQywy6VWINwKwrYbC05lGPxCOdcNYnsIbzvfszHUklFZvDPs1Sta1HaF8LRUmyg9uuv+7+Ajs9egVvHgAA";
    public const string ClayVisland = "H4sIAAAAAAAACu2ZX0/bMBDAv0rl58iznfhf3qYOULfBOqgEA/FgWtNGS+IucZgQ4rvvkqYtHZuENKmqND/Fd3XOF/vX8/n8hM5MYVGKhrl5fHdhytng3DXeDm5OKteAdDUefLYPNs/K+S2KUKtdQvdRnbd94YWpb0z1CD8dOzdDKYnQqSkbk3fNianm1p8Yv7DVyNuiU16ax6XLSl+j9OYJjV2d+cyVKH1CVyhlVGMdcyoj9A2lXGEqJFMsQtcoVQIzpRPxDJIr7egDSinhPELnZpY1YI7idnj3YAtberAVoTEMfZ+V4JivGhuhUeltZab+MvOLL60BsqvrZwPtan/zkbTDgHfd87p7gkv1wv1cvwR9wZ17k9cvxuwM0AgdFc7b9dgwKX3zfdejF742tvYv2xf2x2py3V2vvvBuOXTlrPcMNJ+yPB/CqvlO6tZx+z3DhfFDVxSwbCtF6++lyfzW0VY6dtWu0VY5yQp7Wu+IR5PXkwGTMKrHC1N6V2yMtiuA0rLJc6CnAwFQmjwuwS2t2xfO3MxuerfCR3cH5p6j12wwgmPK2QoNieOYxCswEswTSehfwWC7YJA3gMEIZVrxP+JRF875xeDnIoN/SuWm3wMvh8kLw1IrvQklUibJChiJiSAk2RcwRRdL3f1gllU+wHKQsMQUK0XUOrhIovvgonCiErm34BJYOfyNKOZYM9LnKBLrJJYrVjSOmRIhroSkZcuKxozRNSokkaJnRWBFFQ+sBFY2rCQEcy7W+QqRUqqOFU2xoIzEYQ8Kh6ENKwmmmsabfIXxfhMCWHQsNQuwBFg2sAgsNEtWsAgsKaF9ZCEYSi4BlrALbXchEcNJiPcnoQQLRklfgONQc6H7S2/r5q6wUEGcDeq2bBWKcod4FhJwbhZtNFklLUpppjtaJOxDhBG+P1rmppqa0gZQDjVhIQnj3XgtNJxQ2oHCOWS9nL0ZFPaPoMCNRe7K+cBXNrBysJX+hOpYvCjdqnWxn2MpBVfhFuh/uAW6ff4FzTGK1qMcAAA=";
    public const string MarbleVisland = "H4sIAAAAAAAACu2ZW0/bMBTHv0rl52J8iW99mxigbmNjgMTGtAdDDY2WxF3ibEKI776T1Ckw2LSLVBXJL03sOvaJ/ev/XHqD3trSoQnSeHRg6/PCbb/JS9cEX7nt4+4TjdF+7dsFjJk2ha1mo2NbXYTW1tfw1Z73MzQhY3Rgq9YW/e2Jra9c2Ldh7uppcGXfeWqvFz6vQoMmn27QoW/ykPsKTW7QBzRhFFPFaTZGH9FEciy4omyMztBky1DMqGbiFppgzfRlP9uRneUtTMVxt7T/5kpXhf6bQ1j2Mq/AqEtbNG6MplVwtb0Ip3mYv4uP3++L748e9v5kIOnWAdv661l/BYOauf8+PARjm0dr9hPQMdotfRhM73Yk3r7oR8TG+xZ2/f79sfu63Fl/HrvhPBY7vppFy6DndV4UO76N737k2+Du3mdnbsOOL0s4s2VHZ++pzcOdoV1rz9cPJ+06TwCCg+ZBc/fk8WbAJkybw7mtgi9Xk3ZHgCZVWxSATk9BXl2dXC/ALGO6B976mVuN7hqv/DlMdzt+BAY1WEou9BKMDFOhjIpgEMw5y+TTYLDfgBHq9ikuGKHMaPEkHU3pfZiPvs/z4Ea1v/iScNlEXDjFSismBh2hWlKz0hHKpcjWg0t7XjoQwdmo6X58SVo2kBVGsCBC80FaBM90tmRFC0y0kElakie6w0XgjIGcDNKiBYu0KIVJRs2alCU5oucQtzANgFDK1YALZ8Z0rR4YkBch1b/EtL8gJoW0z8rvSKpN9DugKoRKGcHg2FCWdCTlP6v8R2JCNY+JscSSQRAbYZFYCW5MwiXhstIWSHmM7uRkqS2cGMaXuHQ+yBCeaEm0rMRFYSi68Zgta0xMJmNMmxlsoAi3JlzaK1tf2L7UmGpwGxewCPAzJDNRVEyXNdOoKQZzKhj9I0rYf1KysEU5CrVLlGxkWMuxokZIusREka5qP2ACBBl2P1ChRIg7UOjfg5ISnueT8GxxLOG8jR7IUFTrGMNCeT+TSq1FQOyV/eZGC/gLKyRHs4mgUAIFeyXZUDMhRJkICiVQoKUZXwsoqca2gbry+fYHEqC8FaseAAA=";
    public const string BranchVisland = "H4sIAAAAAAAACu2YX0/bMBDAv0rl58z4T2LHeds6QN0GY1CJjWkPhpo2UmJ3ibNRIb77zknKKLxsLwgh9yU+52yfL7+e73yLjnVtUIEUnrxrtL1a7X1yy71T05YWJeiwcd0a3s7aStvF5AwUfKebzeTNZHZlLt0N6Bw4t0AFSdCRtp2u+uZcN0vjD7VfmWbmTd13nuvN2pXWt6j4fotOXFv60llU3KKvqKAqx5TxNEHfUCEEzgXlMkEX8IYKzAjjdyA5a2bv+8lO9aLsYCaGw8rul6mN9SAm6ARWvS4t2OSbziRoZr1p9JU/L/3qcxjNCGUqz3bfjG6A3VXOLie+MQbtajwymISFwdb+edE/wcJ25X5vB4EuGHitq/aBFf0ENEH7tfPbvQQPjc23vcYofOlM6x+2z8zPwdPucuw+8249dXYxWgY9H8uqmrouOCO4yXXejHuD/UxX2k9dXcPHHDqCvee69H8NDdKBa3YnDZ3zsjZH7Y64P3/qDHDCrD1ZaetdfT9p+CaosF1VAVM9FaVdzjdrMEupMODYLcy9dhA+uEuY7i55CoqkmJCU9utBW0KHGEDhHCtO8ghKBCWAwimmQrEhoqSYMBL+9ABKnmEKPxVBiaAAKIrijGV8BCXDjFOW9qDIDOeKSBFBiaCEiAJwKM6Go0dITEJwAUzSHBOZ5jRiEjHpU1nAhKX59uCBBFYOqawgmHPC4sETQQmgMMZwmuYDKJJhxrLh3OEKC07o85Q8tV65pbabWPO82JqHpZC+piwbIgrFeUYo7UnJMpxlkL38PymP6tJYHb+K6pilBIAQ/XJZSEukzHtQIMkVlJFnCilw/7CYuOvJomx8vEZ5maBAYqIoH0iRWEIFJLekKC4V+ydSQIikvO4LN0hKcM7FEFMEw3kqJB9vZjkGjvizkBJvZl8WKD/u/gBRBFCyPBgAAA==";
    public const string CopperVisland = "H4sIAAAAAAAACu2ZW2/TMBTHv0rl52J8iW99Q+WiggaDTRoX8eC2Zo1I4pI4wDTtu3OceJcyeNjLVG1+aWLHsU/cn/7n4nP01tYOzRAleDL3261rnx6chU1bVmiKXrW+38LDRVfZZj05ss0q9LY9mzyZLFZu6X/DmJfer9GMTNGBbXpbDbfHtj114ZUNG9cugquHzhN7tvVlEzo0+3KODn1XhtI3aHaOPqKZJARLocQUfUIzrrCgumBT9BnNGGNYKqUuoOUbt3g+TPbBrsseZmI4rux/uto1AZpTdAirfisbsCm0vZuiRRNca1fhpAybd/FtRigzWuw+SbuwrPqy20xav/qOdgf8ZS+J64Kpw/XzcAUDu43/dfkSjAX7vtmqu2HEMAGdohe1D5efEjco3T4bRqTG+9514eb9kfsxbrRfpu6j4Ldz36yTZdDzpqyque/jXsRd8n1w6dPge+YbG+a+ruG/HDuivSe2DNeGxtZL3+5OGjuPy9oddDvNF8e3NwM2YdEdbmwTfH01afxL0KzpqwqQGqAom9Pjsy2YZUx84a1fu6vRsfHaL2G6i+ltTgqKqZDDcqzATFNGEyYUk4LSjEnGBDCRHAvBzMAJNZhyxTkfQSEK68Lom6RQIsS1ptC7awr5p5pkCdlLCVEaEyL1sJ7BRnJC1YAG1eBOCBV315C/ZD77mgfhaxTFWio2igjEJ8xIkzSEYwI/2dlkZwOcaIOZEvqSE26MkokT0Betc+yaOUlBiRRRQkZOCAQlKccRMZRVJutJ1hPghIkYoPCRE8h3FGE6cWJAXUROcjInwInQEJNIlTghwIkSSU9MgQ2l9xOf2FP70022UCEKOeHZxzhWxCjE8MQJ1Nak1qloYiBNluZ+/E7mZM/znUJD5UPKsQYLVVdRcDLqCacCF/x+5GRrq3oSWueymOwlJDGIJaQY1oNwBCAZpaRgGJ7dT6qz8iH4Jvuc/dUSAZ5FFyTmweOBjtSUFyMpHJwOFUb/twALxZVcgH3AZzhw1gdnONdnfXC8l0SEwxOuWJFr848XjQKy3CvZEESJS92IaTHVUmY4HgMcXy/+AEYQgZCcIAAA";
    public const string OpalVisland = "H4sIAAAAAAAACu2ZWW/UMBDHv8rKz1vj+9g3VA4tZ2krFYp4cLtmN1ISL4kDVFW/O2MnW1oKCF5QhfwUXxlPnJ8m859coleu8WiBKMWz11tXP3gR1g+O3BbN0dMuDFuYWva1a1ezI9eex8F1F7O92fLcn4WvsOZJCCu0IHP00rWDq3Pz2HVrH5+6uPHdMvomD564i22o2tijxftLdBD6KlahRYtL9BYtGGNYCGPm6B1aaIYZk2KOTtGCW6w4ofwKeqH1y0fZ1qFbVQMYYjhtHD77xrcxzxzAph+rFlyK3eDnaNlG37nzeFLFzet0NyOUWSNvz0xH0LhNWLv2YhY779HtJT84TNLO4Gu+nuYruNhvwpfdTbAWPPzo6v6GG9kAnaPHTYi7h0knNDUf5hVT583g+3izfeQ/jScdzqbhoxi2+6FdTZ7ByPOqrvfDMJ3GYRiinx4Onmd/4+J+aBp4meNA8vfEVfG7o6n3JHS3jabB46rxL/tb3cfHdw8DDmHZH2xcG0NzbTS9FLRoh7oGpjIVVbs+vtiCW9amG16Flb9enTrPwhmYu5rfBYVQrJmQIygKW02ozG9AATSCafFHpLBCyv9OClUUG0YnUmBDYZnKpDCDlRZEFVJKTMmkMI2FNWxHCqfMZFCoAmq4MQWUAkoCRQssmCR2BIVjzhXTmZQ9LrAmkuuCSkEloSIl5sLwkRSJjTScjqRQQrA2JU8pGe2Yp0j4+DCq9S6jVaB2dqgIgzmTtgSVElQyKgIrYRWR12FFWS12rIAYEtKwG7BQIuV3CUT/XgKRn8rkoozvo96RHBNC6Q4NJagehfFe0szEMlnCSAkjWe9Qi8n0wTEyRQ01ZbFQGsNQXGH/pIbi1u6zn22htBhLRLmPEYUahbWiYxILbaKttCMoAkq0gv6jkPKlqlezrev6tkpV6VKVvXekMEg+lJmEsQFhrHgykYUxwdRC5a2QUur3iRQKwYErNRXbLKhkbcVYl91TmIIUor/628N/E1Z++M9SMth7X7H/cPUN/g2j/XscAAA=";
    public const string HempVisland = "H4sIAAAAAAAACu2YzU7cMBCAXyXyOVj+j723agt0W0FpWYmWqgfDGjZSEm8ThxYh3r3jJAts6aUXysGnZGbt8XjyaWZ27tCxrR2aIcpw9s7VG5Sjw9b3G1Atuso2q+zUNpeht+1ttpctLt2F/wVrDrxfoRnJ0ZFtelsNr0vbXrtwaMPatYvg6kF5Zm83vmxCh2bf7tCJ78pQ+gbN7tAXNJOGYSKNytFXNKMck0JrnaNzEMAfo4y4B8k3bvF2MPbZrsoeLMEuONnfuNo1AcQcncCpV2UDPoW2dzlaNMG19jKclWH9Me5mhDKj5e4v093ttb1x2QZuG9Dugj/8JfFccHV4ng9PcLBb+5/bTbAW/LuyVffEicEAzdF+7cP2KjFA0+ubYcUkfOpdF56+n7ofY6D9xaQ+DX4z981q8gw0H8qqmvs+xiJGyffBTVeD+8zXNsx9XcO3HBXR3zNbhkdHo3Tg212jUbksa3fU7Yj7y+fBgCAsupM1xM/XD0bjJ0Gzpq8qQGqAomyul7cbcMuYuOHYr9zD6ii89xdg7j5/zgnXWDEuRk40ZkRyNnJCDGaaJ04SJwMnDEtKJk4IFgUXfOBEUQyoqJROUjoBTBjBVCi6xYQYI8aywxQ2ksqEScIEMKEGG+gaRkwggWhSiAGTPYKVUlQpnkhJpMS6w7EQUx9rMFdcs7HuUGw0ZJcicZI4AU4Ew4LTh8LDCh2FmFG4wpwRoxMoCRQApSC4IGzgpMCFVkJMlUeCCCklFZ7ESeREG0y4HDjRWAtGlRk5MQIXnBmT8knKJ8CJgq6E87GVFVhQqchYeBS0soa+0KCthhnVKvNX2aps06jtdY7apAQgCj62KAX8T+ZTSoG5CmQY+TIZZWOrOgutc2kg+yopMQRzSbYTWR47WW0eR/ecUf50ikKJlI+s8H9nhfyVkgTH/4fj+/1vjMGRNUQaAAA=";
    public const string MulticoloredVisland = "H4sIAAAAAAAACu2ZW2/TMBTHv0rl587yNbb7hsqYChoMNmlcxIPbemu0JO4SBxjTvjsnaZKtdKA9TQX5KbHjOMenP/3Ppbforc0dmiDK8ei4zkJ6MPWZL91yhMboqPT1Gh7OqswWy9GpLRahtuXN6GA0W7i5/wFrXnm/RBMyRse2qG3W3p7Z8tKFIxtWrpwFl7eT5/Zm7dMiVGjy5Rad+CoNqS/Q5BZ9RBNGCKYm4WP0CU2ooZgoocfoM5oc8ERgLRS7g6Ev3OwlLCBSjtEHu0xr2I3h5uv+m8tdEdpPncCXL9IC7LqwWeXGaFYEV9pFOE/D6l2zAyOUGS23n3SuyBs3LDovpFXm5pn3eYW2F/92ANIYAba318/tFQyuVv57/xKsrXYMajegY3SY+9AeDd5uPNbdvmhXdIP3tavCw/tTd73xvJ9306fBr6e+WHaWwcybNMumvu4c88HXwXXHhPNMVzZMfZ7Dj7uZaOw9t2m4N7QZvfLl9qbN5Fmau+Nqa3h4tusMcMKsOlnZIvh82LT5fdCkqLMMGGspSYvLs5s1mGVM88Jbv3TD6mbw2s9hu7vxDjjUMKw10wM4lPXcKOBGCxO5idzscsOowIwnpuOGYCkN7cDREitu5LOBcw2aGn6OLnyZ29bEqDR7qDSMSkwSnXTEMEwT0RMDI0O1jsTE2LRFDMNKqgcSo/vYZDjmlEZgIjDbWbDBQsghmyFYGGMGZmgbpMQfVYb+JS6Fsn4sLJFHA1IMQPsYgKjR2OheTiiQovkGDUEpTohSMdWNqe5j3BisKKEDOFBssx4cgznTPIITwdkFhwuOleaiBQcKIiy4EB04BCptQsxTYxHAF2PRf9R24UJhzSTr0BDQdjFdMOImwYYlz6cp0KS8XI3mmV1cjUq/uIrZy34Sk2CliBqIYTRRvZhAogvYPBsx1dotrjLo7kZc9ldgDNZcD7RIyfqchUhQGxlr51g7bwEjIbGlRt7ri5Ak6ZHhWCaE/rmlG0vn//pfIi4ZZupeTYgRQ+zRoDMJjdlKbN0+7MRxBYWx2KgJUwZLYbr4wzXFJiFPbsPF0udf1pKvd78AVO4u1iMhAAA=";
    public const string IronVisland = "H4sIAAAAAAAACu2Y3U/bMBDA/5XKz8XyZxznbeoAdRMfg0psTHtwW0MjkrhLnG0I8b9zSZNAYUx9nMBPsS/O+Xz56Xx3d+jY5BYliAo8mpauGJ2UFo3RYenqNYinVWaK5ejcFAtfm/J2tDeaLuzc/YE1B84tUULG6MgUtcna4cyU19YfGr+y5dTbvBVemNu1SwtfoeT7HTp1VepTV6DkDn1FiRQC8zgWY/QNJZQJTCNBx+gSJXuMM0xlxO5h6go7/dhqOzPLtAZVDDdbu182t4Vv35zCtldpAUb5srZjNC28Lc3CX6R+ddJ8zQhlOpbbbzoHwIGvV6N5ZhY3o9ItbtD2qmdWk2ZzMLh9XrZPsLJaud/9R7AWjLwyWfXEklYBnG4/d74/T+OmbvihXdFNvtS28k/H5/bnxt1u3onPvVtPXLHsLAPJ5zTLJq7uHHLmam+788F5JivjJy7P4Y9uBI29Fyb1j4Y2swNXbitthLM0t0fV1nR/9tIZ4IRpdboyhXf5oLT5Lygp6iwDsFo00uJ6drsGs7RuPjh2Szusbiaf3BzU3Y9f0qIYjrmiHS0xZlzLjpZIY6Go2okWFmh5D7RIhSOl9EALIXEfW5TEmrLdYkug5T3QIiC2EC67m0hIrBThHS1NpIlkgCVcRD0snGOtdTzAArEm6mChBKKOFIGWQEtPC2FYEM43tESQ8cqop4UpzISIAy2Blo4WriGT1VIOtEQi6tMWpjGnOya5WyXRs0ok1ERvJ28hBHOogwZcJKeqxwWymJjQgEuILgMuDLoqnKsNLjGBzEV0tEAaQxTR4SoKV1EPi6QQTpqiuYWFQneO9LTIGEdMRoGWQMtAi8axYOqRFhkPsUVhEu9YFIXE5X00XCKKtSRkixfJ+ua/xtCrZ/wJMZQ0SXEPDf9Hk+61bJf8tfcfev3/Ix5SUBwr0ZVBDPotkWBDHQTNXKole5UOGuh4Q8Hjx/0Dd8ZTp6ocAAA=";
    public const string LaverJellyfishVisland = "H4sIAAAAAAAACu1ZXU/bMBT9K5WfM+Pv2HmbOkBlgzFaiY1pD4a6NFISl8RhQoz/PjtJSwsv0yYhmPwUX39cX9+cnnvi3oMTXRqQAczh6JO+NfXe9KbN56NfoyNTFHeLvFnujW2ti9GhdktTgwQc1rZd+SWTptDVfDTV1ZVrdX3nhw6snYMMJeBYV60uuuZM19fG9asnzpRd57m+W9m8cg3Ivt+DU9vkLrcVyO7BV5ClKIWEC5qAbyB7xwRUgqo0ARfeIt5iSsoHb9rKTD6ADCPOE3Cm53nr3REYtre3pjSV82YCTv3Wi7zygbm6NQmYVM7U+sqd5275OTggCBMl+e7IkJfG6J/GzEdOV9eFAbtznsSNwtY+5O550T19mM3S/lwv8nN9iAtdNFtxdA5wAvZL67oD+dUhUUPzfTdjML60pnHb7am56RNuL4fuqbOrsa3mQ2S+52NeFGPbhnR468y2zgyn8+cZL7Ub27L0r7LvCPGe69w9BhqsA1vvOg2ds7w0x82OuT97ngyfhElzutSVs+XGaXgrIKvaovCI6sCRV9ezu5UPS6mw4MTOzWZ2MI7spXf3kDzHC2FQUKkGvHAoJeUDXJiHSyr5S8HlqvupLGxd6i7AiJfXiBeMIUeSbPGLwj1eKEyZ8EORXiK9bODiGUXIVPZw4QhKQbjq8IIpRILzv6tGT8pA5Jf/ph5xCVPCB7xQKAlWrOcXBDFjWIoXK0hRv7wBvARRK5kY6pGEBFFEOsBQBRFRLOqXqHd39YsUDPd4ocSLX5L2gpdRb1CcRr0bBcwjXiiFWFG8ETCUSdEL3pRDxb2EieUo6t1HeuGQYLH+nPZf0ILgXr9gRKFCVER6iXjZwouEEgfB0uGFwDQVuL+uw5RBKtIXK0dR7b4NtZum62oU6EUS3lcjjAnkRKlIL5Fetq5fMMRy/WcAg5jzUJsCXMK9rxfDfwoX9K+3L5FeXhu9/Hj4DQYNeNnCGgAA";
    public const string RocksaltVisland = "H4sIAAAAAAAACu2YW0/bMBSA/0rk59ayHV/zNnWAugnGoBIb0x7cxtBoSdwlDluF+O84N2g3HpgmMTRZqpScE1+OTz/5XG7BiS4MSAAWMDqzq2+1zh2YgKPKNhuvnte5LtPoXJcr1+hqG02j+cos7U8/5tDaFCRoAo512ei8e13o6tq4I+3Wppo7U3TKC73d2Kx0NUi+3IJTW2cusyVIbsEnkHAZQyyYmIDPIMEwpphKOQGXIJliTiFHgtx50ZZm/rZb7UynWeOXIrDd2t6YwpSu+3Lqt73KSm+UqxozAfPSmUqv3EXm1h/a2QRhoiTb/zI4YFVta6fz6dKf16RR5X0B9gf+Yjhq9/c2d8/L7ukNrdf2xzjJj/V2Xum83jGmWwBPwEFh3Xik1lPD65tuxCB8bEztdt/Pzffe43Y5qM+d3cxsmQ6Wec37LM9nthl8cmYbZ4Yj+vPM1trNbFH4Q/aK1t4LnblHQ1vp0Fb7i7bKRVaY43pPPFj87gzvhHl9utals8XDou1fA5KyyXPPVkdHVl4vthtvllLthBObmofRrfDOLv1yd5MngeFYqGE/xQiVjI/EeCoEV4GYQMw+MYrEIzGUUUTxAAxjEDMpAjABmF1gMCQxjwdgZCz8j4xXDIJCShaICcTsEuPvFYHoQAxTjGM0BiXGIaYq3DGBmF1ihIByxIUrIYkYcZGQyxCSAi67uDCloFKkJ0ZCRiUW8QAMIhAjGj8rIpG/LJMKX1mkkb2K0qxqC8VQIL26AolJBVHMBlIkJZirnhRFoYiJUi9Cir7WNyba+P5B4ORVFtJM+EwWkW474XNaTintOWFeVFK9zI0SOHnlDRdGCaQxxn2HDkEiZCu0oMQcxgQpGUAJnbn2QsG+z4L6yEMhIwo9NOYU9HHnmUltyFH+/yauYpAr3nf9p35DTrhkbVO3L4GUz1vivT4uRow9EoP/nBj0ZPQJKey/x+Pr3T0v5i8xhxoAAA==";
    public const string LeucograniteVisland = "H4sIAAAAAAAACu2YTVPbMBCG/0pG56DRt2zfOikwbgulkBn6MT0oiUg82FZqy20Zhv/etSMDgR5aDillnEssaS2t5Gd2X+01OjaFRQmiGo/e2WbulpUpM2/RGB1WrlnDUFrnplyMzkw5942prkZ7o3RuZ+4n2Bw4t0AJGaMjUzYm7x6nplpaf2j8ylapt0XXeW6u1i4rfY2SL9foxNWZz1yJkmv0ESUq5lgrGo/RJ5RIDOafUbKnhMI6YvENNF1p09fdRKdmkTUwC2vNjtx3W9jSdyMnsOJFVoI/vmrsGKWlt5WZ+/PMr963bzNCWRzJ7ZGw/3pt55e5XYwqN79E2yYPvCXtyuAoCY7CP7hYr9yP/iWwBQ8vTF7fc6ObgI7RfuF8v5n2eMLjq84iND40tvb3n8/st80xu1noPvNuPXHlIngGPW+zPJ+4JpzGqWu8DZuD/UxWxk9cUcCX3HS0/p6bzN852rYOXLU9ads5zQp7VG8196ePDwMOIa1PVqb0rridtP0oKCmbPAegOiSycjm9WoNbMXzvtD52C3tr3TbeuBlMdzN+TIkmWHOmAyVUR1EARQocs0j+EShsAOXFgyIlZrGKuvVizKjkWgVUKKASR3pAZYgpHSpMYEXlJvNQgiURVPTpR2KpSDSgMqDSoUIZZpyLHpVIaSp7VBjoF0V3olRmeZPVq0GnPNv0I2OFKRGsTz+caEoDKEpDuNFPSD8PxOSgaV+GVJERxwKka2BFgr5lvapV7ZAWOwkqcNVbrkaz3Mwvh8jyfGnRFNIO75ZTcOVRSugAS9TqXDaIlUGsbEgREEx4yxegEmERSRL3V6AY7s7w200OGtTKc89AQmMak41akW0ZTpIgazXlmOmY7eQGNGSg/0KvyBhTwWighTPIQDzQwqE8R/UT4spQrn2RVTiQJBGhfCNX2rIb/O6KKwJHTKp7sFAi5R0v/O95Ib+NK0Mt/9/D8fXmF8gIf5poGgAA";
    public const string QuartzVisland = "H4sIAAAAAAAACu2YTU/cMBCG/8rK59R17Dixc6u2gLYtdIGVoCAOZtewEUm8JE4rQPz3TkI+2AKH9rBaVJ/iz8nYeTTzZh7Qgco0itFhpQp7/3FSmHx0fjodfTNmdYE8tFeYagXzkzJV+WJ0rPK5haV3MLVrzALFxEP7Kq9U2jRnqrjWdk/ZpS4mVmfN4Im6W5kktyWKzx/Q1JSJTUyO4gd0imIWRFhQTj30AzoywD6VzENnKP7AZIglDdkjdE2uJ58ba0dqkVRgiuL61eanznRum5kpvPYqycGpK5WW2kOT3OpCze1JYpff6+2UgHXB12faG4CDXi9Hl6ma34wKM79B66v+cJvUbwePm+dZ8wQ3y6X51W2CteULTxoDvod2MmO7A9X31DY/NSvazmGlS/u8faxvn+7bXLbDx9asxiZftJ7ByNckTcemam/kyFRWt+eD84yXyo5NlsGXfBqo/T1RiR0crXu7plg3Wg/Okkzvl2vdndnLy4BLmJTTpcqtyXqj9YdBcV6lKQDVsJHk17O7FbglZb3hwCx0v7rufDGXYO7RewWXEEcRiXpcqB9GT7gEhOAAmNkMLuVKz29SvXCsbDErEkeS+UNsYZREwUBLyLngr+NCMOV/zQt5lRQXSLYTDooFoV0gYVgS4XdoRJiySG4mkNw2mXd0ZYpMNf65vLOVuEgsmOgjCeeUdrRw0CxcOFqcSulp4RTTaKCFyKAXKQI4Cn2naR0tAy0h5ozLHhfJ6DNcJHtDo7hM9F/+AXGJaz3R0yLCUHa0BPBz5Dvh4oLLgEvoY5+EQa9zIyHb4MKkxJywwOUil4uG6CJArdR/Qi0uIuqiC5NQqQvJhspxrr7yDjIRx4xEfKjFhUFbXWGSYxk52eICywCLj5mgz2jxRVeLY1JAHZeHbwDD/iG0uFLce1K0UJmVNQwtGSBR/EGiiIBvKOe4Utz24XLx+Bv/TmvkpBwAAA==";
    public const string CoalVisland = "H4sIAAAAAAAACu2aS2/UMBDHv8rK563xK37sDS20WlChtJXKQxzcXbcbkcRL4gBV6XdnknXSFjiUS2nBp9iO40ycn2b+M8klemVLh2aIGjyZe1s8OVrbwk2+T/aKvGzWtfclmqK92rcbmLVoClutJke2WobW1heTncli6U79N5iz6/0KzcgU7duqtUXfPLb1uQt7NqxdvQiu7AdP7MXG51Vo0OzDJTrwTR5yX6HZJXqLZoJzzIXSU/QOzYzBnHLBpug9mu0wobCmXF1B11du8axf7dCu8haWYri7tf/iSleF/swB3PYsr8CoULduihZVcLVdhpM8rF93VzNCmdHZ7TNxP84L/zWvzidnbXUOy9+e85PNpLs1mNsf3/dHsLFZ+6/DRTAXTDyzRXPDjn4BOkXPSx+Gp+k2KTaf9jNi503rmnCzfeQ+bzfbn8bho+A3c1+tomUw8jIvirlv43Yc+ja4+HTwPPO1DXNflvA+twOdvSc2D9eGdr1dX99etBs8zku339zqPj/+dTNgExbNwdpWASAaFu3eCppVbVEAVj0YsM3HFxswy5jugld+5cbZXeeFP4Xlrqa/ssLgpWuxRUVjkzGmIyoZxzKj5l5QWfpy0xnmJrVffkqoPExUOCbSsNGtkGtWJMFSMp5YSW4lskIwM3T0K0JwaSIrCqIT1SyxklgZ5QpVZGSFEZHJyAq4GamFvBMr4JiSXPnX5YoiWLMhBmXQljRKW55prBS9H1aSXnkMrBgslBhZIdooHlmREtIgmrKgFIK2qGiGJWcRFQFpkJA0oqIEzgxJGXNiZXArkAYxrUe3QjhRkRUtMWRJKQ1KrAzSNsOUCT36FaoHt6IhQWJ3K64kYfsf1OG4wlJkZiBFK/Arg1hRmBJ1PxEoCdvHwIrATHK6ZUViLq8jECRBVMgsKdukbLeskAyDllVjIY4SKa6LK0zcrQ6X8uV/PwRxQzA1OoYgjTNCVFQrTAvQvFIkt5LcypYVDcU22pXeOlYUNlqLG/V9c18hKMmVh+9XBAW5Qk2UK6BlefdrQo8KpViTO9bhUhb0f3xiNppno1/Z/gyywzjBQkuif08K/XNSyG/dSfrx4O9T8fHqB7uw0yFRJQAA";
    public const string WaterVisland = "H4sIAAAAAAAACu2aTU/bMBjHv0rlc7FiO37LbeoAdROMjUrdmHYwrUujJXGXOGwI8d33JCSFUg5lBwTMp8SO6zx2fvo/L+41Oja5RQmiER7sLxa2vLTVzBZ+MDXelmiIDktXr2DAuMpMMR+cmmLma1NeDfYG45k9d39gzIFzc5REQ3Rkitpk7e3ElBfWHxq/tOXY27ztnJqrlUsLX6Hk+zU6cVXqU1eg5Bp9RQnVAnNK9BB9Q4nkmGqlyRCdoWSPxgrHUsgbaLrCjt+3s30x87SGqShuXu0ubQ6Gt09O4LWLtACjfFnbIRoXsBgz89PULz81v6YRgen55pNuKypvMnORp96izecP7I2a14Kp7fWsvYJ91dL97n8EY8G8hcmqeza0E8C69nPn+5U0G9TdvmtHdI3Pta38/ftT++t2o915133q3WrkinlnGfR8TLNs5OpuK7642ttuZbCe0dL4kctz+Ja3HY29U5P6O0Ob1oErNydtOidpbo+qjeb+ZHszYBPG1cnSFN7l60mbL4KSos4yQKqFIi0uJlcrMEvDFx9Xx25u16Obxgd3DtPdDLc4YRFvYOA9J7xjhMeYKcqehZGZy1eNVXZQutnPwMmL5IRwHGkW95wQTbnqWVFYEh0HPQl6ApwwLJQUD/VEMByxKBKPQ0I2BYXuICjRo1ISxONFigeTmEJEsoaCaio6MKTGTOzoaHbhIgQjrzgYoRLHWscPxUOB75H8eYKRELC+dEYIViAoW4wQDL6H0Z0czAYkD1KK4GFeadhBxZ2HARwi2ZMBHgY8TlCPEJ4CJxJLTVjPiYyZZB0nWmEiIhI4CZwAJwRzSFhoD4qgJOpAYVGT4ij1dE8TUpm3AUbM1lxIIrjuuIASCWc81FWDgDR1VSiyc0nXuQzkNXoNCsNcCPEPChJi1TcgIREEpLo5jelLqZr3rgXCEy5UiFWDhDRHeFD2IPFd1UzHsst2GdFYxMHTBEwaTDRUx2K5VTWDfEYSONp7esk9eJnX72WoUlipmG3VyWJMSbzbYV2ot799D6OEII/EqFQCJ0wH9fgf/hby4+Yv+9V2y7skAAA=";
    public const string CrystalVisland = "H4sIAAAAAAAACu2ZUU/bMBDHv0rk58w4dhzHeZs6YN0EY9CJwbSH0Jo2Iom7xBmqGN995zQpLUVTYVJVtjzFdu3L2f7l7/P1Dh3HmUIRoh52erOiNHG69z6+vXHO4nzk/HIuVJrqW6enp1NV7B3qdOR8KhRy0WGhqykM/JKPbUmNoO1A6xGKiIuO4ryK07o4iIuxMoexmaiib1RWN57Hs6lOclOi6NsdOtFlYhKdo+gOfUUR5QT7jFMXXaCIUyxD4TMXXaLojed7mAvu3UNV56r/DkUe4dxFp/EoqcAaxfbt+qfKVG6g6qITePN1koNf13FaKhf1c6OKeGjOEzP5ZC1Q4lEZ8tVfmmWZ1dNPyolT6OENWu3zyG9i3w0u18/L+gl+lhN92w6CvuWaH7UBz0X7mTb1jGC0Xaim+Lbu0VQ+V6o0y+Uz9WO+4PqqaT4zetrT+ajxDFo+Jmna05VdD6id6sqoZnYwn94kNj2dZbDb8wbr73mcmAdHbe1AF6tGbeMgydRRuVLdH6wvBixCvzyZxLnR2cKo3RYU5VWaAko1HEk+Hsym4JaUdsCxHqlFb1v5oK/A3L37BC8BlkSEC14kJaLhxaM4EGH4Il5MUT0Xl6RM7WczLGb2Q3KGaVVCnw6bncRGeJhy8SAzIqRhgw2oIZOUb4oN+UtsOpV5BSoTEhwQtqQyfisyNMDEl9uCpdOYV3Q0SR+HoRBzaFgTGAAxcCyFokOmi2aeQEZiQgh9jAwLsJAh61SmC4DXjyYfLkls6WSS7X2JSRwwvnH82wUy/8F1KQgwD6hY4MIl4e25JHEomfciXLrr9T/KiyRYBmwuL4LjhhXqB5h5ZGtX67HNw+Rj57rKx2C+y8TsJCogLdSTLSqwmdJrcQmxLwKxrZPI5l/icZYYm6vsknY7iIqPGWuPoSVZ4ZCV8dkfUnbe80EhTyLSgbGLGsIIt0LB17gAXkLKthaaDHU2tZ6pLvO/u6EJ3I8Dzuy/Q/PLMvO5bGNZiE9gewO+qZBsEqB0QrKrcev3+99gotpTyxwAAA==";

    // Placeholder while I'm getting the XP Routes done (then the rest should come into place)
    public const string DummyVisland = "Dummy";
}
