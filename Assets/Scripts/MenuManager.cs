using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Menu _mainMenuPrefab;
    [SerializeField] Menu[] _menus;
    [SerializeField] Transform _menuParentTransform;

    private Stack<Menu> _menuStack = new Stack<Menu>();
    private static MenuManager _instance;
    public static MenuManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MenuManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("MenuManager");
                    _instance = go.AddComponent<MenuManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            InitMenus();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void InitMenus()
    {
        if (_menuParentTransform == null)
        {
            GameObject menuObject = new GameObject("Menus");
            _menuParentTransform = menuObject.transform;
        }

        DontDestroyOnLoad(_menuParentTransform.gameObject);

        foreach (Menu prefab in _menus)
        {
            Menu menuInstance = Instantiate(prefab, _menuParentTransform);
            menuInstance.gameObject.SetActive(false);
        }

        Menu mainMenuInstance = Instantiate(_mainMenuPrefab, _menuParentTransform);
        MenuManager.Instance.OpenMenu(_mainMenuPrefab);
    }

    public void OpenMenu(Menu menuInstance)
    {
        if (menuInstance == null)
            Debug.LogWarning($"[OpenMenu] Menu is Null");
        menuInstance.gameObject.SetActive(true);
        if (_menuStack.Count > 0)
        {
            foreach (Menu menu in _menuStack)
            {
                menu.gameObject.SetActive(false);
            }
        }
        _menuStack.Push(menuInstance);
    }

    public void CloseMenu()
    {
        if (_menuStack.Count > 0)
            _menuStack.Pop().OnBackPressed();
        else
            Debug.LogWarning($"닫을 메뉴가 없습니다");

        if (_menuStack.Count > 0)
            MenuManager.Instance.OpenMenu(_menuStack.Peek());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenu();
        }
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
