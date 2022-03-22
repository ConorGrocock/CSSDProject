import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import Locize from "i18next-locize-backend";
import LanguageDetector from 'i18next-browser-languagedetector';

i18n
    .use(initReactI18next) // passes i18n down to react-i18next
    .use(Locize)
    .use(LanguageDetector)
    .init({
        lng: "en",
        debug: true,
        saveMissing: true,
        saveMissingTo: "all",
        interpolation: {
            escapeValue: false // react already safes from xss
        },
        backend: {
            projectId: "5f3297ed-d615-46c8-a6e8-3ad31d895b37",
            apiKey: "9589e16e-2120-45b7-966e-07c345f6fa26",
            private: true,
            referenceLng: "en",
            allowedAddOrUpdateHosts: ["localhost"]
        }
    });

export default i18n;