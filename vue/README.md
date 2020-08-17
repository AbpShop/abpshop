# AbpShop Admin
## 开发规范
统一使用ES6 语法
方法注释
/*
* th => 表头
* data => 数据
* fileName => 文件名
* fileType => 文件类型
* sheetName => sheet页名
*/
export default function toExcel ({ th, data, fileName, fileType, sheetName }) 
行注释 //

### 命名

页面目录 文件夹命名格式骆驼式命名法,例如：用户列表 userList 
例如：商品模块
product 商品
    ├─ product 商品管理
        ├─productList 商品管理目录
            ├- index.vue  首页
        ├─ components  组建
            ├─ tableFrom.vue
            ├─ tableList.vue
        ├─ handle 操作功能页面目录
            ├─ delete.vue
    ├─productCategory 商品分类目录
        ├─ index.vue 商品分类首页

页面命名、组建、文件夹 命名格式小驼峰命名法,例如：用户列表 userList

类名函数命名 大驼峰式 例如：addUser
变量命名 小驼峰式 例如：user 或者 userInfo _userinfo user-info
常量 采用全大些下划线命名 例如：VUE_APP_API_URl

### 文件管理规范
pages 页面模块必须件文件夹区分
api 接口一个模块一个文件
组建 一个组建一个文件夹
plugins 插件一个插件一个文件夹
vuex 路由状态管理，一个模块在modules 中建一个文件夹
router 一个模块一个模块在modules 中建一个文件夹
style 样式尽量采用iView自带组建，common.less 系统通用样式不要轻易动
自定义通用样式 style.less,每次添加必须加注释，页面独立样式在在页面内写，后缀less 格式
组建样式 styles 中添加文件夹 composents 对应components 目录新建样式文件
utils 自定义工具js 独立命名，一般不用新建文件夹

## 模块命名
~~~
├─ product 商品管理
├─ user 用户管理
├─ order 系统订单管理
├─ setting 系统设置维护 系统权限管理、系统菜单管理 客服管理
├─ chat 客服管理（列表，添加，删除，编辑）
├─ application 各个应用模块功能管理公众号、小程序、支付宝、百度小程序、今日头条小程序
├─ system 系统更新日志 数据库管理
├─ finance  财务管理
├─ agent 分销管理
├─ marketing 优惠券、积分、拼团、砍价、秒杀
├─ echarts 数据统计分析
├─ notification  消息通知管理、模版消息（列表，通知，添加，编辑）、短信
├─ file 附件文件管理
├─ freight 运费模版管理 物流公司
├─ merchant 商户管理
├─ widget 组件 小插件
└─ cms 文章管理
~~~
## 目录结构
主要目录结构及说明：
~~~
├── public                # 静态资源
│   ├── favicon.ico       # favicon图标
│   └── index.html        # html 模板
├── src                   # 源代码
│   ├── api               # 所有请求
│   ├── assets            # 图片、svg 等静态资源
│   ├── components        # 公共组件
│   ├── i18n              # 多语言
│   ├── layouts           # 布局
│   ├── libs              # 公共方法
│   ├── menu              # 菜单配置
│   ├── mixins            # 通用混合
│   ├── mock              # 数据模拟
│   ├── pages             # 所有页面
│   ├── plugins           # 插件
│   ├── router            # 路由配置
│   ├── store             # Vuex 状态管理
│   ├── styles            # 样式管理
│   ├── setting.env.js    # 开发配置文件
│   ├── setting.js        # 业务配置文件
│   ├── main.js           # 入口文件 加载组件 初始化等
│   └── App.vue           # 入口页面
├── tests                 # 测试管理
├── alias.config.js       # 别名，仅用于配置 WebStorm 识别别名，无实际用处
├── babel.config.js       # babel 配置
├── jest.config.js        # jest 配置
├── package.json          # package.json
└── vue.config.js         # Vue CLI 3 配置
~~~
## 开发打包项目
~~~
# 进入项目目录
$ cd admin-iView

# 安装依赖
$ npm install

# 启动项目(本地开发环境)
$ npm run dev

# 打包项目
$ npm run build
~~~

## 配置


