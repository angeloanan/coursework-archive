\NeedsTeXFormat{LaTeX2e}
\ProvidesClass{assignment}[2022/03/28] % By Christopher Angelo <angelo@angeloanan.xyz>

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

% General macros
\newcommand{\professor}[1]{ \newcommand{\professorloc}{#1} }
\newcommand{\class}[1]{ \newcommand{\classlocal}{#1} }
\newcommand{\institute}[1]{ \newcommand{\instituteloc}{#1} }

% Auxiliary macros, maily for i18n
\newcommand{\CourseLang}{Course}
\newcommand{\DateLang}{Due date}
\newcommand{\StudentLang}{Student name}
\newcommand{\ProfessorLang}{Professor}

% Header, footers, titles
\RequirePackage{fancyhdr}

\usepackage[utf8]{inputenc} % Required for inputting international characters
\usepackage[T1]{fontenc} % Output font encoding for international characters

\usepackage{booktabs} % Required for better horizontal rules in tables

% Hyperlinks setup
% \usepackage{hyperref}
% \hypersetup{
%     colorlinks=true,
%     linkcolor=blue,
%     filecolor=magenta,      
%     urlcolor=cyan,
%     pdftitle={Overleaf Example},
%     pdfpagemode=FullScreen,
% }
% \urlstyle{same}

% https://tex.stackexchange.com/questions/5091/what-to-do-to-switch-to-biblatex
% https://tex.stackexchange.com/questions/527497/is-there-a-way-to-apply-apa-7th-references-and-citation-style-in-latex
\usepackage[style=apa, backend=biber]{biblatex}
\addbibresource[]{sources.bib}

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%%% Options
%%%% We now pass the options of the class

% Only compile for single column, non-doublesided paper
\DeclareOption{twocolumn}{\OptionNotUsed}
\DeclareOption{twoside}{\OptionNotUsed}

% Bahasa Indonesia
\DeclareOption{indonesian}{
    \renewcommand{\CourseLang}{Kelas}
    \renewcommand{\ProfessorLang}{Dosen}
    \renewcommand{\DateLang}{Tenggat Waktu}
    \renewcommand{\StudentLang}{Nama Mahasiswa}
}

\PassOptionsToClass{a4paper}{article}

\DeclareOption*{\PassOptionsToClass{\CurrentOption}{article}}

\ProcessOptions\relax

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%%% Bulk Declarations
%%%% Here we do more declarations and call other files


% we need to load 
\LoadClass{article}


% we will modify sections, subsections and sub subsections
\RequirePackage{titlesec}
% Modification of section 
\titleformat{\section}[block]{\normalsize\bfseries\filcenter}{\thesection.}{.3cm}{} 

% modification of subsection and sub sub section
\titleformat{\subsection}[runin]{\bfseries}{ \thesubsection.}
{1mm}{}[.\quad]
\titleformat{\subsubsection}[runin]{\bfseries\itshape}{ \thesubsubsection.}
{1mm}{}[.\quad]

% Geometry lets us modify the sizes of the document nicely
\RequirePackage{geometry}
% Margins for printing
\geometry{left=2.5cm,right=2.5cm,top=2.5cm,bottom=2.5cm}

\fancyhead{}
\fancyfoot{}
\pagestyle{fancy}
\renewcommand{\headrulewidth}{0.4pt} % we want rules 
\renewcommand{\footrulewidth}{0.4pt}
\fancyhead[RO] {\footnotesize\thepage}
\fancyhead[LO] {\footnotesize{\ifx\classlocal\undefined{}\else\itshape\classlocal{} --{} \fi}\makeatletter\@title\makeatother }
\fancyfoot[RO] {\footnotesize\itshape\makeatletter\@author\makeatother}

% New title style for the document
\renewcommand{\maketitle}{%
    \thispagestyle{plain}
    \begin{center}
        \ifx\instituteloc\undefined{}\else{\scshape \instituteloc} \\[10pt] \fi
        \hrule
        \vspace{10pt}
        {\LARGE \bfseries \@title} \\[5pt]
        \StudentLang: {\itshape \@author}
        \vspace{8pt}
        \hrule
        \vspace{10pt}
        \ifx\classlocal\undefined{}\else\CourseLang: {\itshape \classlocal{} \ifx\professorloc\undefined{}\else{-- }\fi  }\fi
        \ifx\professorloc\undefined{}\else{\ProfessorLang: {\itshape\professorloc}}\fi 
        \\
        \DateLang: {\itshape\@date}
        \vspace{20pt}
    \end{center}
}

% definition of the "problem" environment
\newsavebox{\problembox}
\newenvironment{problem}
    {\begin{center} \begin{lrbox}{\problembox}\begin{minipage}{.98\textwidth}}
    {\end{minipage}\end{lrbox}\fbox{\usebox{\problembox}} \end{center} }

\endinput
